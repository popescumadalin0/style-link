using Microsoft.AspNetCore.Mvc;

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