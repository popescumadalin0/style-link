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

public class ServiceController : Controller
{
    private readonly ILogger<ServiceController> _logger;

    private readonly IServiceSalonService _serviceSalonService;
    private readonly IServiceTypeRepository _serviceTypeRepository;

    public ServiceController(
    ILogger<ServiceController> logger,
    IServiceSalonService serviceSalonService,
    IServiceTypeRepository serviceTypeRepository)
    {
        _logger = logger;
        _serviceSalonService = serviceSalonService;
        _serviceTypeRepository = serviceTypeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> AddServiceAsync()
    {
        await SetViewBagServiceTypes();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddServiceAsync(AddServiceModel model)
    {
        await SetViewBagServiceTypes();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _serviceSalonService.AddServiceAsync(model);

        return RedirectToAction("AddHairStylist", "Hairstylist");
    }

    [HttpPost]
    public async Task<IActionResult> AddServiceTypeAsync(AddServiceModel model)
    {
        await _serviceTypeRepository.CreateServiceTypeAsync(new ServiceType()
        {
            Name = model.ServiceType,
        });

        return RedirectToAction("AddService", "Service");
    }

    private async Task SetViewBagServiceTypes()
    {
        var serviceTypes = await _serviceTypeRepository.GetServiceTypesAsync();
        ViewBag.ServiceTypes = serviceTypes.Select(h => new SelectListItem()
        {
            Text = h.Name,
            Value = h.Name,
        }).ToList();
    }
}