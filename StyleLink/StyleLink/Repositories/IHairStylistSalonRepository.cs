using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface IHairStylistSalonRepository
{
    Task<List<HairStylistSalon>> GetHairStylistSalonsAsync();

    Task<HairStylistSalon> GetHairStylistSalonAsync(Guid id);

    Task DeleteHairStylistSalonAsync(Guid id);

    Task CreateHairStylistSalonAsync(HairStylistSalon model);
}