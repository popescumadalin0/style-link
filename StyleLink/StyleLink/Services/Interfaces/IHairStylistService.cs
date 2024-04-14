using System.Collections.Generic;
using System.Threading.Tasks;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface IHairStylistService
{
    Task<List<AddHairStylistModel>> GetAddHairStylistsAsync();

    Task AddHairStylistAsync(AddHairStylistModel model);
}