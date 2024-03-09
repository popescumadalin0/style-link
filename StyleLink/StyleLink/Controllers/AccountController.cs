using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;

namespace StyleLink.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel login)
    {
        if (!ModelState.IsValid)
        {
            return View(login);
        }

        //get token
        //save token

        return RedirectToAction("Index", "Home");
    }
    public IActionResult Logout()
    {
        //todo: logout
        return RedirectToAction("Login", "Account");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterModel register)
    {
        if (!ModelState.IsValid)
        {
            return View(register);
        }

        //save account

        return RedirectToAction("Login", "Account");
    }

    public IActionResult Details()
    {
        return View();
    }
}