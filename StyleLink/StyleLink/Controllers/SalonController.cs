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
        var mock = new SalonModel();
        return View(mock);
    }
}