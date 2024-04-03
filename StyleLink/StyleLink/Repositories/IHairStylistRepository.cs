using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface IHairStylistRepository
{
    Task<List<HairStylist>> GetHairStylistsAsync();

    Task<HairStylist> GetHairStylistAsync(Guid id);

    Task DeleteHairStylistAsync(Guid id);

    Task CreateHairStylistAsync(HairStylist model);
}