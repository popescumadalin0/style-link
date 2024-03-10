using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Enums;
using StyleLink.Models;

namespace StyleLink.Controllers;

public class AppointmentsController : Controller
{
    private readonly ILogger<AppointmentsController> _logger;

    public AppointmentsController(ILogger<AppointmentsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Appointments()
    {
        //todo: get appointments

        var mockAppointments = new List<AppointmentModel>()
        {
            new()
            {
                AppointmentStatus = AppointmentStatus.Finished,
                Currency = "RON",
                EndDate = DateTime.Now,
                HairStyleName = "Gabriel Ceranu",
                SalonName = "Vintage Salon",
                ServicePrice = 50,
                ServiceType = "Tuns",
                StartDate = DateTime.Now.AddDays(-1),
            },
            new()
            {
                AppointmentStatus = AppointmentStatus.Finished,
                Currency = "RON",
                EndDate = DateTime.Now,
                HairStyleName = "Gabriel Ceranu",
                SalonName = "Vintage Salon",
                ServicePrice = 50,
                ServiceType = "Tuns",
                StartDate = DateTime.Now.AddDays(-1),
            },
            new()
            {
                AppointmentStatus = AppointmentStatus.Finished,
                Currency = "RON",
                EndDate = DateTime.Now,
                HairStyleName = "Gabriel Ceranu",
                SalonName = "Vintage Salon",
                ServicePrice = 50,
                ServiceType = "Tuns",
                StartDate = DateTime.Now.AddDays(-1),
            },
            new()
            {
                AppointmentStatus = AppointmentStatus.Finished,
                Currency = "RON",
                EndDate = DateTime.Now,
                HairStyleName = "Gabriel Ceranu",
                SalonName = "Vintage Salon",
                ServicePrice = 50,
                ServiceType = "Tuns",
                StartDate = DateTime.Now.AddDays(-1),
            },
            new()
            {
                AppointmentStatus = AppointmentStatus.Finished,
                Currency = "RON",
                EndDate = DateTime.Now,
                HairStyleName = "Gabriel Ceranu",
                SalonName = "Vintage Salon",
                ServicePrice = 50,
                ServiceType = "Tuns",
                StartDate = DateTime.Now.AddDays(-1),
            }
        };

        return View(mockAppointments);
    }
}