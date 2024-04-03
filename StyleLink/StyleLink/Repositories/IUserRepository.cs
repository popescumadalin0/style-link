using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();

    Task<User> GetUserAsync(Guid id);

    Task DeleteUserAsync(Guid id);

    Task CreateUserAsync(User model);
}