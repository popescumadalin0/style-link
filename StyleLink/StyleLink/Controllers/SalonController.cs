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
        var haistylists = await _hairStylistService.GetAddHairStylistsAsync();
        return View(new AddSalonModel()
        {
            Hairstylists = haistylists
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddSalonAsync(AddSalonModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _salonService.AddSalonAsync(model);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> AddHairStylistAsync()
    {
        var services = await _serviceSalonService.GetAddServicesAsync();
        var hairStylist = new AddHairStylistModel()
        {
            Services = services
        };
        return View(hairStylist);
    }

    [HttpPost]
    public async Task<IActionResult> AddHairStylistAsync(AddHairStylistModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _hairStylistService.AddHairStylistAsync(model);

        return RedirectToAction("AddSalon", "Salon");
    }

    [HttpGet]
    public async Task<IActionResult> AddServiceAsync()
    {
        var serviceTypes = await _serviceTypeRepository.GetServiceTypesAsync();
        var list = new SelectList(serviceTypes.Select(x => new SelectListItem(x.Name, x.Name)).ToList(), "Value",
            "ServiceType.Name");
        ViewBag.ServiceTypes = list;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddServiceAsync(AddServiceModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _serviceSalonService.AddServiceAsync(model);

        return RedirectToAction("AddHairStylist", "Salon");
    }

    [HttpPost]
    public async Task<IActionResult> AddServiceTypeAsync(AddServiceModel model)
    {
        await _serviceTypeRepository.CreateServiceTypeAsync(new ServiceType()
        {
            Name = model.Name,
        });

        return null;
    }
}