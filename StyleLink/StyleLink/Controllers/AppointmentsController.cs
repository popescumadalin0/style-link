using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Enums;
using StyleLink.Models;
using static System.Net.WebRequestMethods;

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
                HairStylistName = "Gabriel Ceranu",
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
                HairStylistName = "Gabriel Ceranu",
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
                HairStylistName = "Gabriel Ceranu",
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
                HairStylistName = "Gabriel Ceranu",
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
                HairStylistName = "Gabriel Ceranu",
                SalonName = "Vintage Salon",
                ServicePrice = 50,
                ServiceType = "Tuns",
                StartDate = DateTime.Now.AddDays(-1),
            }
        };

        return View(mockAppointments);
    }

    [HttpGet]
    public IActionResult AppointmentDetails(string id)
    {
        //todo: get appointment detail
        var mock = new AppointmentDetailModel()
        {
            SalonAddress = "Calea București 105, Craiova 200477, România",
            AppointmentStatus = AppointmentStatus.Finished,
            Currency = "RON",
            HairStylistName = "Gabriel Ceranu",
            MapsUrl =
                "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2854.6821616514094!2d23.817478476558076!3d44.3164842092794!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4752d700473c2c27%3A0xae7b558912b0012c!2sVintage%20Salon!5e0!3m2!1sen!2sro!4v1710195231230!5m2!1sen!2sro",
            UserRating = 5,
            SalonName = "VintageSalon",
            SalonPhoneNumber = "0771 143 646",
            ServicePrice = 50,
            ServiceType = "Tuns",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            SalonId = Guid.NewGuid().ToString(),
        };

        return View(mock);
    }
}