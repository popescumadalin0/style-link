using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public async Task<bool> SignInAsync(string userName, string password)
    {
        var isLogged = await _signinManager.PasswordSignInAsync(userName, password, false, false);
        return isLogged.Succeeded;
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

    public async Task<User> GetUserAsync(string name)
    {
        var user = await _userManager.Users.FirstAsync(u => u.UserName == name || u.Email == name);

        return user;
    }

    public async Task<IdentityResult> DeleteUserAsync(Guid id)
    {
        var user = await _userManager.Users.FirstAsync(s => s.Id == id);

        return await _userManager.DeleteAsync(user);
    }

    public async Task<IdentityResult> UpdateUserAsync(User user)
    {
        var result = await _userManager.UpdateAsync(user);

        return result;
    }

    public async Task<IdentityResult> UpdateUserEmailAsync(User user, string newEmail, string token)
    {
        var result = await _userManager.ChangeEmailAsync(user, newEmail, token);
        return result;
    }

    public async Task<IdentityResult> UpdateUserPasswordAsync(User user, string oldPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        return result;
    }

    public async Task<IdentityResult> UpdateUserPhoneNumberAsync(User user, string newPhoneNumber, string token)
    {
        var result = await _userManager.ChangePhoneNumberAsync(user, newPhoneNumber, token);
        return result;
    }

    public async Task<IdentityResult> DeleteUserAsync(string name)
    {
        var user = await _userManager.Users.FirstAsync(s => s.UserName == name || s.Email == name);

        return await _userManager.DeleteAsync(user);
    }

    public async Task<IdentityResult> CreateUserAsync(User model, string password)
    {
        var result = await _userManager.CreateAsync(model, password);

        return result;
    }
}