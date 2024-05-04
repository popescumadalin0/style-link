using System;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IUserRepository _userRepository;

    public AccountController(
        ILogger<AccountController> logger,
        IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
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

        await _userRepository.SignInAsync(login.Email, login.Password);

        return RedirectToAction("Index", "Home");
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
        //todo:
        /*await _userRepository.CreateUserAsync(new User()
        {
            Id = Guid.NewGuid(),
            ProfileImage = register.ProfileImage,
        })*/

        return RedirectToAction("Login", "Account");
    }

    public async Task<IActionResult> DetailsAsync()
    {
        //get user details
        //todo:
        //var user = await _userRepository.GetUserAsync()

        var user = new UpdateUserModel()
        {
            Email = "test@test.com",
            PhoneNumber = "0763519884",
            FirstName = "Madalin",
            LastName = "Popescu"
        };

        return View(user);
    }

    [HttpPost]
    public IActionResult Details(UpdateUserModel model)
    {
        //HttpPostedFileBase file = Request.Files["ImageData"];
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        //todo: save
        return View(model);
    }

    public async Task<IActionResult> DeleteAccountAsync()
    {
        //todo:
        //await _userRepository.DeleteUserAsync();
        return RedirectToAction("Logout", "Account");
    }
}