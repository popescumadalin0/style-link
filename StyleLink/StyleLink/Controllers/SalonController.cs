using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using StyleLink.Constants;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class SalonController : Controller
{
    private readonly ILogger<SalonController> _logger;

    private readonly ISalonService _salonService;
    private readonly IHairStylistService _hairStylistService;

    public SalonController(
    ILogger<SalonController> logger,
    ISalonService salonService,
    IHairStylistService hairStylistService)
    {
        _logger = logger;
        _salonService = salonService;
        _hairStylistService = hairStylistService;
    }

    [HttpGet]
    public async Task<IActionResult> SalonAsync(string id)
    {
        _logger.LogInformation($"{nameof(SalonAsync)} was called!");

        var salon = await _salonService.GetSalonDetailsAsync(Guid.Parse(id));

        return View(salon);
    }

    [HttpGet]
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> AddSalonAsync()
    {
        await SetHairStylistsInViewBag();

        return View();
    }

    [HttpPost]
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> AddSalonAsync(AddSalonModel model)
    {
        await SetHairStylistsInViewBag();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _salonService.AddSalonAsync(model);

        return RedirectToAction("Index", "Home");

    }

    private async Task SetHairStylistsInViewBag()
    {
        var hairstylists = await _hairStylistService.GetAddHairStylistsAsync();

        ViewBag.HairStylists = hairstylists.Select(h => new SelectListItem()
        {
            Text = h.FirstName + " " + h.LastName,
            Value = h.Id.ToString(),
        }).ToList();
    }
}