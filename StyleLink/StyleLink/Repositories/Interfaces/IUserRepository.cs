using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();

    Task<User> GetUserAsync(Guid id);

    Task DeleteUserAsync(Guid id);

    Task CreateUserAsync(User model);
}