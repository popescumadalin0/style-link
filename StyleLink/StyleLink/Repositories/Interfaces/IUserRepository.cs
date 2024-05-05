using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Identity;

namespace StyleLink.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> SignInAsync(string userName, string password);

    Task SignOutAsync();

    Task<List<User>> GetUsersAsync();

    Task<User> GetUserAsync(Guid id);

    Task<User> GetUserAsync(string name);

    Task<IdentityResult> DeleteUserAsync(Guid id);

    Task<IdentityResult> UpdateUserAsync(User user);

    Task<IdentityResult> UpdateUserEmailAsync(User user, string newEmail, string token);

    Task<IdentityResult> UpdateUserPasswordAsync(User user, string oldPassword, string newPassword);

    Task<IdentityResult> UpdateUserPhoneNumberAsync(User user, string newPhoneNumber, string token);

    Task<IdentityResult> DeleteUserAsync(string name);

    Task<IdentityResult> CreateUserAsync(User model, string password);
}