using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SignInManager<User> _signinManager;
    private readonly UserManager<User> _userManager;

    public UserRepository(
        SignInManager<User> signinManager,
        UserManager<User> userManager)
    {
        _signinManager = signinManager;
        _userManager = userManager;
    }

    public async Task SignInAsync(User user)
    {
        await _signinManager.SignInAsync(user, false);
    }

    public async Task SignInAsync(string userName, string password)
    {
        await _signinManager.PasswordSignInAsync(userName, password, false, false);
    }

    public async Task SignOutAsync()
    {
        await _signinManager.SignOutAsync();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();

        return users;
    }

    public async Task<User> GetUserAsync(Guid id)
    {
        var user = await _userManager.Users.FirstAsync(s => s.Id == id);

        return user;
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _userManager.Users.FirstAsync(s => s.Id == id);

        await _userManager.DeleteAsync(user);
    }

    public async Task CreateUserAsync(User model)
    {
        await _userManager.CreateAsync(model);
    }
}