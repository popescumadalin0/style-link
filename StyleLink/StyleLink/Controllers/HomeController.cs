using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISalonService _salonService;

    public HomeController(ILogger<HomeController> logger, ISalonService salonService)
    {
        _logger = logger;
        _salonService = salonService;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation($"{nameof(Index)} was called!");

        var salons = await _salonService.GetSalonsAsync();

        return View(salons);
    }
}