using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using System.Collections.Generic;

namespace StyleLink.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //todo: get salons

        var mockSalons = new List<SalonModel>()
        {
            new()
            {
                SalonName = "VintageSalon",
                Address = "Calea București, Craiova",
                NumberOfEvaluations = 9301,
                SalonRating = 4.83,
                ImagesTest = new List<string>()
                {
                    "~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg"
                },
                ProfileImageTest =  "~/images/fb.jpg"

            },
            new()
            {
                SalonName = "VintageSalon",
                Address = "Calea București, Craiova",
                NumberOfEvaluations = 9301,
                SalonRating = 4.83,
                ImagesTest = new List<string>()
                {
                    "~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg"
                },
                ProfileImageTest =  "~/images/fb.jpg"
            },
            new()
            {
                SalonName = "VintageSalon",
                Address = "Calea București, Craiova",
                NumberOfEvaluations = 9301,
                SalonRating = 4.83,
                ImagesTest = new List<string>()
                {
                    "~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg"
                },
                ProfileImageTest =  "~/images/fb.jpg"
            },
            new()
            {
                SalonName = "VintageSalon",
                Address = "Calea București, Craiova",
                NumberOfEvaluations = 9301,
                SalonRating = 4.83,
                ImagesTest = new List<string>()
                {
                    "~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg"
                },
                ProfileImageTest =  "~/images/fb.jpg"
            },
            new()
            {
                SalonName = "VintageSalon",
                Address = "Calea București, Craiova",
                NumberOfEvaluations = 9301,
                SalonRating = 4.83,
                ImagesTest = new List<string>()
                {
                    "~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg","~/images/fb.jpg"
                },
                ProfileImageTest =  "~/images/fb.jpg"
            },
        };

        return View(mockSalons);
    }
}