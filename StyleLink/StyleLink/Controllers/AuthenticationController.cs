using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StyleLink.Models;

namespace StyleLink.Controllers;

public class AuthenticationController : Controller
{
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }
}