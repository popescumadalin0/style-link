using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StyleLink.Constants;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Repositories;

public class HairStylistRepository : IHairStylistRepository
{
    private readonly UserManager<User> _userManager;

    public HairStylistRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<User>> GetHairStylistsAsync()
    {
        var hairStylists = await _userManager.GetUsersInRoleAsync(Roles.HairStylist);

        return hairStylists.ToList();
    }

    public async Task<User> GetHairStylistAsync(Guid id)
    {
        var hairStylist = await _userManager.Users.FirstAsync(s => s.Id == id);

        return hairStylist;
    }

    public async Task<IdentityResult> DeleteHairStylistAsync(Guid id)
    {
        var hairStylist = await _userManager.Users.FirstAsync(s => s.Id == id);

        return await _userManager.DeleteAsync(hairStylist);
    }

    public async Task<IdentityResult> CreateHairStylistAsync(User model, string password)
    {
        return await _userManager.CreateAsync(model, password);
    }
}