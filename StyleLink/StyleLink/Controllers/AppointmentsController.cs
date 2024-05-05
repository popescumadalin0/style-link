using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class AppointmentsController : Controller
{
    private readonly ILogger<AppointmentsController> _logger;

    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(
        ILogger<AppointmentsController> logger,
        IAppointmentService appointmentService)
    {
        _logger = logger;
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<IActionResult> AppointmentsAsync()
    {
        _logger.LogInformation($"{nameof(AppointmentsAsync)} was called!");

        var appointments = await _appointmentService.GetAppointmentsAsync(User.Identity?.Name);

        return View(appointments);
    }

    [HttpGet]
    public async Task<IActionResult> AppointmentDetailsAsync(Guid id)
    {
        _logger.LogInformation($"{nameof(AppointmentDetailsAsync)} was called!");

        var appointment = await _appointmentService.GetAppointmentDetailsAsync(id);

        return View(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> AddAppointmentAsync(SalonDetailModel model)
    {
        //todo: select the available time
        /*await _appointmentService.CreateServiceTypeAsync(new ServiceType()
        {
            Name = model.ServiceType,
        });*/

        return RedirectToAction("Salon", "Salon");
    }
}