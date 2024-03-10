using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StyleLink.Controllers;

public class TermsAndConditionsController : Controller
{
    private readonly ILogger<TermsAndConditionsController> _logger;

    public TermsAndConditionsController(ILogger<TermsAndConditionsController> logger)
    {
        _logger = logger;
    }

    public IActionResult TermsAndConditions()
    {
        return View();
    }
}