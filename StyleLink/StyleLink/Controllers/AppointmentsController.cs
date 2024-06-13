using System;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Constants;
using StyleLink.Enums;
using StyleLink.Models;
using StyleLink.Repositories.Interfaces;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class AppointmentsController : Controller
{
    private readonly ILogger<AppointmentsController> _logger;

    private readonly IAppointmentService _appointmentService;

    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentsController(
        ILogger<AppointmentsController> logger,
        IAppointmentService appointmentService,
        IAppointmentRepository appointmentRepository)
    {
        _logger = logger;
        _appointmentService = appointmentService;
        _appointmentRepository = appointmentRepository;
    }

    [HttpGet]
    [Authorize(Roles = Roles.User)]
    public async Task<IActionResult> AppointmentsAsync()
    {
        _logger.LogInformation($"{nameof(AppointmentsAsync)} was called!");

        var appointments = await _appointmentService.GetAppointmentsAsync(User.Identity?.Name);

        return View(appointments);
    }

    [HttpGet]
    [Authorize(Roles = Roles.HairStylist)]
    public async Task<IActionResult> HairStylistAppointmentsAsync()
    {
        _logger.LogInformation($"{nameof(AppointmentsAsync)} was called!");

        var appointments = await _appointmentService.GetHairStylistAppointmentsAsync(User.Identity?.Name);

        return View("Appointments", appointments);
    }

    [HttpGet]
    [Authorize(Roles = Roles.User)]
    public async Task<IActionResult> AppointmentDetailsAsync(Guid id)
    {
        _logger.LogInformation($"{nameof(AppointmentDetailsAsync)} was called!");

        var appointment = await _appointmentService.GetAppointmentDetailsAsync(id);

        return View(appointment);
    }

    [HttpPost]
    [Authorize(Roles = Roles.User)]
    public async Task<IActionResult> AddAppointmentAsync(SalonDetailModel model)
    {
        //todo: select the available time
        /*await _appointmentService.CreateServiceTypeAsync(new ServiceType()
        {
            Name = model.ServiceType,
        });*/

        await _appointmentRepository.CreateAppointmentAsync(new Appointment()
        {
            //HairStylistService = "",
            Id = Guid.NewGuid(),
            StartDate = DateTime.Now,
            Status = AppointmentStatus.Pending,
            //User = 
        });

        return RedirectToAction("Salon", "Salon", new { id = model.Id.ToString() });
    }
}