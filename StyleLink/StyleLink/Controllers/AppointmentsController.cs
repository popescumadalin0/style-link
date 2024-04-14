using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

    public async Task<IActionResult> AppointmentsAsync()
    {
        _logger.LogInformation($"{nameof(AppointmentsAsync)} was called!");

        var appointments = await _appointmentService.GetAppointmentsAsync();

        return View(appointments);
    }

    [HttpGet]
    public async Task<IActionResult> AppointmentDetailsAsync(Guid id)
    {
        _logger.LogInformation($"{nameof(AppointmentDetailsAsync)} was called!");

        var appointment = await _appointmentService.GetAppointmentDetailsAsync(id);

        return View(appointment);
    }
}