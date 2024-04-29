using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class SalonController : Controller
{
    private readonly ILogger<SalonController> _logger;

    private readonly ISalonService _salonService;
    private readonly IHairStylistService _hairStylistService;
    private readonly IImageConvertorService _imageConvertorService;

    public SalonController(
    ILogger<SalonController> logger,
    ISalonService salonService,
    IHairStylistService hairStylistService,
    IImageConvertorService imageConvertorService)
    {
        _logger = logger;
        _salonService = salonService;
        _hairStylistService = hairStylistService;
        _imageConvertorService = imageConvertorService;
    }

    [HttpGet]
    public async Task<IActionResult> SalonAsync(string id)
    {
        _logger.LogInformation($"{nameof(SalonAsync)} was called!");

        var salon = await _salonService.GetSalonDetailsAsync(Guid.Parse(id));

        ViewBag.ProfileImage = await _imageConvertorService.ConvertFormFileToImageAsync(salon.ProfileImage);
        foreach (var salonImage in salon.Images)
        {
            ViewBag.Images.Add(await _imageConvertorService.ConvertFormFileToImageAsync(salonImage));
        }

        foreach (var salonHairStylist in salon.HairStylists)
        {
            ViewBag.HairStylists.Add(salonHairStylist.Id, await _imageConvertorService.ConvertFormFileToImageAsync(salonHairStylist.ProfileImage));
        }

        return View(salon);
    }

    [HttpGet]
    public async Task<IActionResult> AddSalonAsync()
    {
        await SetHairStylistsInViewBag();

        return View();
    }

    [HttpPost]
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