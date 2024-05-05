using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Constants;
using StyleLink.Models;
using StyleLink.Repositories.Interfaces;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class FavoriteController : Controller
{
    private readonly ILogger<FavoriteController> _logger;
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly IFavoriteService _favoriteService;

    public FavoriteController(
        ILogger<FavoriteController> logger,
        IFavoriteRepository favoriteRepository,
        IFavoriteService favoriteService,
        IImageConvertorService imageConvertorService)
    {
        _logger = logger;
        _favoriteRepository = favoriteRepository;
        _favoriteService = favoriteService;
    }

    [Authorize(Roles = Roles.User)]
    public async Task<IActionResult> FavoriteAsync()
    {
        _logger.LogInformation($"{nameof(FavoriteAsync)} was called!");

        var favorites = await _favoriteService.GetFavoritesAsync(User.Identity?.Name);

        return View(favorites);
    }

    [HttpPost]
    [Authorize(Roles = Roles.User)]
    public async Task<IActionResult> AddFavoriteAsync(SalonDetailModel model)
    {
        _logger.LogInformation($"{nameof(AddFavoriteAsync)} was called!");
        await _favoriteService.CreateFavoriteAsync(model.Id, User.Identity?.Name);

        return RedirectToAction("Salon", "Salon");
    }

    [HttpPost]
    [Authorize(Roles = Roles.User)]
    public async Task<IActionResult> DeleteFavoriteAsync(FavoriteModel model)
    {
        _logger.LogInformation($"{nameof(DeleteFavoriteAsync)} was called!");
        await _favoriteRepository.DeleteFavoriteAsync(model.Id);

        return RedirectToAction("Favorite", "Favorite");
    }
}