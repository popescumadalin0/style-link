using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;

namespace StyleLink.Controllers;

public class FavoriteController : Controller
{
    private readonly ILogger<FavoriteController> _logger;

    public FavoriteController(ILogger<FavoriteController> logger)
    {
        _logger = logger;
    }

    public IActionResult Favorite()
    {
        //todo: get favorites

        var mockFavorites = new List<FavoriteModel>()
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
                }
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
                }
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
                }
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
                }
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
                }
            },
        };

        return View(mockFavorites);
    }

    [HttpDelete]
    public IActionResult DeleteFavorite(string id)
    {
        //todo: delete favorite

        return RedirectToAction("Favorite", "Favorite");
    }
}