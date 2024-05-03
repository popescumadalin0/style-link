using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;
public class HairstylistController : Controller
{
    private readonly ILogger<HairstylistController> _logger;

    private readonly IHairStylistService _hairStylistService;
    private readonly IServiceSalonService _serviceSalonService;

    public HairstylistController(
    ILogger<HairstylistController> logger,
    IHairStylistService hairStylistService,
    IServiceSalonService serviceSalonService)
    {
        _logger = logger;
        _hairStylistService = hairStylistService;
        _serviceSalonService = serviceSalonService;
    }


    [HttpGet]
    public async Task<IActionResult> AddHairStylistAsync()
    {
        await SetViewBagServicesAsync();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddHairStylistAsync(AddHairStylistModel model)
    {
        await SetViewBagServicesAsync();

        for (var i = 0; i < model.ServiceDetails.Count; i++)
        {
            model.ServiceDetails[i].ServiceId = ViewBag.Services[i].Value;
            if (!model.ServiceDetails[i].IsUsed)
            {
                model.ServiceDetails[i].Currency = "notNull";
                model.ServiceDetails[i].Price = 0;
                model.ServiceDetails[i].Time = TimeOnly.MinValue;
                ModelState[$"ServiceDetails[{i}].Time"].ValidationState = ModelValidationState.Valid;
                ModelState[$"ServiceDetails[{i}].Price"].ValidationState = ModelValidationState.Valid;
                ModelState[$"ServiceDetails[{i}].Currency"].ValidationState = ModelValidationState.Valid;

            }
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _hairStylistService.AddHairStylistAsync(model);

        return RedirectToAction("AddSalon", "Salon");
    }

    private async Task SetViewBagServicesAsync()
    {
        var services = await _serviceSalonService.GetAddServicesAsync();

        ViewBag.Services = services.Select(h => new SelectListItem()
        {
            Text = h.Name,
            Value = h.Id.ToString(),
        }).ToList();
    }
}