using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IContext _context;

    public UserRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task<User> GetUserAsync(Guid id)
    {
        var user = await _context.Users.FirstAsync(s => s.Id == id);

        return user;
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _context.Users.FirstAsync(s => s.Id == id);

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }

    public async Task CreateUserAsync(User model)
    {
        await _context.Users.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}