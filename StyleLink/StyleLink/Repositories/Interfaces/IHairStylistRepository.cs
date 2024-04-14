using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IHairStylistRepository
{
    Task<List<HairStylist>> GetHairStylistsAsync();

    Task<HairStylist> GetHairStylistAsync(Guid id);

    Task DeleteHairStylistAsync(Guid id);

    Task CreateHairStylistAsync(HairStylist model);
}