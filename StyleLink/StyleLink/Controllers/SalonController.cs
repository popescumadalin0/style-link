using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;

namespace StyleLink.Controllers;

public class SalonController : Controller
{
    private readonly ILogger<SalonController> _logger;

    public SalonController(ILogger<SalonController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Salon(string id)
    {
        var mock = new SalonModel()
        {
            ImagesTest = new List<string>() { "~/images/fb.jpg", "~/images/fb.jpg", "~/images/fb.jpg", "~/images/fb.jpg", "~/images/fb.jpg" },
            SalonName = "VintageSalon",
            SalonAddress = "Calea București 105, Craiova",
            MapsUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d5708.961862427529!2d23.805721908691392!3d44.32062044605852!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4752d700473c2c27%3A0xae7b558912b0012c!2sVintage%20Salon!5e0!3m2!1sro!2sro!4v1710363238277!5m2!1sro!2sro",
            ProfileImageTest = "~/images/fb.jpg",
            TimeSchedule = new TimeSchedule()
            {
                Monday = "9:00 - 20:00",
                Tuesday = "9:00 - 20:00",
                Wednesday = "9:00 - 20:00",
                Thursday = "9:00 - 20:00",
                Friday = "9:00 - 20:00",
                Saturday = "9:00 - 20:00",
                Sunday = "9:00 - 20:00",
            },
            HairStylists = new List<HairStylist>()
            {
                new()
                {
                    Name = "Gabriel Ceranu",
                    ProfileImageTest = "~/images/fb.jpg"
                },
                new()
                {
                    Name = "Gabriel Ceranu",
                    ProfileImageTest = "~/images/fb.jpg"
                },
                new()
                {
                Name = "Gabriel Ceranu",
                ProfileImageTest = "~/images/fb.jpg"
                }
            },
            NumberOfEvaluations = 9304,
            SalonRating = 4.93,
            Services = new List<ServiceModel>()
            {
                new()
                {
                    Currency = "lei",
                    MaxPrice = 100,
                    MinPrice = 50,
                    MinServiceDuration = DateTime.Now,
                    MaxServiceDuration = DateTime.Now,
                    ServiceCategory = "Tuns",
                    ServiceName = "Tuns"
                }
            }
        };
        return View(mock);
    }
}