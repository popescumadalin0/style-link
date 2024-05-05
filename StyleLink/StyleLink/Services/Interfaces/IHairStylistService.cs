using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface IHairStylistService
{
    Task<List<AddHairStylistModel>> GetAddHairStylistsAsync();

    Task<IdentityResult> AddHairStylistAsync(AddHairStylistModel model);
}