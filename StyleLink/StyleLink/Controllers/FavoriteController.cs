using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        return View();
    }
}