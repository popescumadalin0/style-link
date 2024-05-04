using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IUserRepository
{
    Task SignInAsync(User user);

    Task SignInAsync(string userName, string password);

    Task SignOutAsync();

    Task<List<User>> GetUsersAsync();

    Task<User> GetUserAsync(Guid id);

    Task DeleteUserAsync(Guid id);

    Task CreateUserAsync(User model);
}