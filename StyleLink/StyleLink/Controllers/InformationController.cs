using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StyleLink.Controllers;

public class InformationController : Controller
{
    private readonly ILogger<InformationController> _logger;

    public InformationController(ILogger<InformationController> logger)
    {
        _logger = logger;
    }

    public IActionResult TermsAndConditions()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }
}