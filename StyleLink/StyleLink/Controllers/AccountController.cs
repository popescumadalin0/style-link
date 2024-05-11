using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using StyleLink.Constants;
using StyleLink.Models;
using StyleLink.Repositories.Interfaces;
using StyleLink.Services.Interfaces;

namespace StyleLink.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public AccountController(
        ILogger<AccountController> logger,
        IUserRepository userRepository,
        IUserService userService)
    {
        _logger = logger;
        _userRepository = userRepository;
        _userService = userService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginModel login)
    {
        if (!ModelState.IsValid)
        {
            return View(login);
        }

        var result = await _userRepository.SignInAsync(login.Email, login.Password);
        if (result)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "The email or password are incorrect!");
        return View(login);
    }
    public async Task<IActionResult> LogoutAsync()
    {
        await _userRepository.SignOutAsync();

        return RedirectToAction("Login", "Account");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegisterModel register)
    {
        if (!ModelState.IsValid)
        {
            return View(register);
        }

        var result = await _userService.RegisterAsync(register);

        if (result.Succeeded)
        {
            return RedirectToAction("Login", "Account");
        }

        foreach (var identityError in result.Errors)
        {
            ModelState.AddModelError(identityError.Code, identityError.Description);
        }

        return View(register);
    }

    public async Task<IActionResult> DetailsAsync()
    {
        var user = await _userService.GetUserDetailAsync(User.Identity?.Name);

        return View(user);
    }

    [HttpPost]
    [Authorize(Roles = Roles.User)]
    public async Task<IActionResult> DetailsAsync(UpdateUserModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var result = await _userService.UpdateUserAsync(model);

        foreach (var identityError in result.Errors)
        {
            ModelState.AddModelError(identityError.Code, identityError.Description);
        }

        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    [Authorize(Roles = Roles.User)]
    public async Task<IActionResult> DeleteAccountAsync()
    {
        var result = await _userRepository.DeleteUserAsync(User.Identity?.Name);
        if (result.Succeeded)
        {
            return RedirectToAction("Logout", "Account");
        }

        foreach (var identityError in result.Errors)
        {
            ModelState.AddModelError(identityError.Code, identityError.Description);
        }

        return RedirectToAction("Details", "Account");
    }
}