using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StyleLink.Controllers;

public class AppointmentsController : Controller
{
    private readonly ILogger<AppointmentsController> _logger;

    public AppointmentsController(ILogger<AppointmentsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Appointments()
    {
        return View();
    }
}