using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Repositories.Interfaces;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class SalonController : Controller
{
    private readonly ILogger<SalonController> _logger;

    private readonly ISalonService _salonService;
    private readonly IHairStylistService _hairStylistService;
    private readonly IServiceSalonService _serviceSalonService;
    private readonly IServiceTypeRepository _serviceTypeRepository;

    public SalonController(
    ILogger<SalonController> logger,
    ISalonService salonService,
    IHairStylistService hairStylistService,
    IServiceSalonService serviceSalonService,
    IServiceTypeRepository serviceTypeRepository)
    {
        _logger = logger;
        _salonService = salonService;
        _hairStylistService = hairStylistService;
        _serviceSalonService = serviceSalonService;
        _serviceTypeRepository = serviceTypeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> SalonAsync(string id)
    {
        _logger.LogInformation($"{nameof(SalonAsync)} was called!");

        var salon = await _salonService.GetSalonDetailsAsync(Guid.Parse(id));

        return View(salon);
    }

    [HttpGet]
    public async Task<IActionResult> AddSalonAsync()
    {
        var hairstylists = await _hairStylistService.GetAddHairStylistsAsync();

        ViewBag.HairStylists = hairstylists.Select(h => new SelectListItem()
        {
            Text = h.FirstName + " " + h.LastName,
            Value = h.Id.ToString(),
        }).ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddSalonAsync(AddSalonModel model)
    {
        var hairstylists = await _hairStylistService.GetAddHairStylistsAsync();

        ViewBag.HairStylists = hairstylists.Select(h => new SelectListItem()
        {
            Text = h.FirstName + " " + h.LastName,
            Value = h.Id.ToString(),
        }).ToList();
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _salonService.AddSalonAsync(model);

        return RedirectToAction("Index", "Home");
    }
}