using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Identity;

namespace StyleLink.Repositories.Interfaces;

public interface IHairStylistRepository
{
    Task<List<User>> GetHairStylistsAsync();

    Task<User> GetHairStylistAsync(Guid id);

    Task<IdentityResult> DeleteHairStylistAsync(Guid id);

    Task<IdentityResult> CreateHairStylistAsync(User model, string password);
}