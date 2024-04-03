using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Repositories;

namespace StyleLink.Controllers;

public class FavoriteController : Controller
{
    private readonly ILogger<FavoriteController> _logger;
    private readonly IFavoriteRepository _favoriteRepository;

    public FavoriteController(ILogger<FavoriteController> logger, IFavoriteRepository favoriteRepository)
    {
        _logger = logger;
        _favoriteRepository = favoriteRepository;
    }

    public async Task<IActionResult> FavoriteAsync()
    {
        var favorites = await _favoriteRepository.GetFavoritesAsync();

        var favoritesDto = favorites.Select(f => new FavoriteModel()
        {
            Address = f.Salon.Address,
            Id = f.Id,
            SalonId = f.Salon.Id,
            SalonName = f.Salon.Name,
            //Images = f.Salon.SalonImages.Select(si => si.Content).ToList(),
            ImagesTest = f.Salon.SalonImages.Select(si => si.Content).ToList(),
            //ProfileImage = f.Salon.ProfileImage,
            ProfileImageTest = f.Salon.ProfileImage,
            NumberOfEvaluations = f.Salon.ReviewCount,
            SalonRating = f.Salon.Rating
        }).ToList();

        return View(favoritesDto);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteFavoriteAsync(FavoriteModel model)
    {
        await _favoriteRepository.DeleteFavoriteAsync(model.Id);

        return RedirectToAction("Favorite", "Favorite");
    }
}