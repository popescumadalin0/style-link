using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Repositories.Interfaces;
using StyleLink.Services;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class FavoriteController : Controller
{
    private readonly ILogger<FavoriteController> _logger;
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly IFavoriteService _favoriteService;
    private readonly IImageConvertorService _imageConvertorService;

    public FavoriteController(
        ILogger<FavoriteController> logger,
        IFavoriteRepository favoriteRepository,
        IFavoriteService favoriteService,
        IImageConvertorService imageConvertorService)
    {
        _logger = logger;
        _favoriteRepository = favoriteRepository;
        _favoriteService = favoriteService;
        _imageConvertorService = imageConvertorService;
    }

    public async Task<IActionResult> FavoriteAsync()
    {
        _logger.LogInformation($"{nameof(FavoriteAsync)} was called!");

        var favorites = await _favoriteService.GetFavoritesAsync();

        return View(favorites);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteFavoriteAsync(FavoriteModel model)
    {
        _logger.LogInformation($"{nameof(DeleteFavoriteAsync)} was called!");
        await _favoriteRepository.DeleteFavoriteAsync(model.Id);

        return RedirectToAction("Favorite", "Favorite");
    }
}