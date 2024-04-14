using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IHairStylistSalonRepository
{
    Task<List<HairStylistSalon>> GetHairStylistSalonsAsync();

    Task<HairStylistSalon> GetHairStylistSalonAsync(Guid id);

    Task DeleteHairStylistSalonAsync(Guid id);

    Task CreateHairStylistSalonAsync(HairStylistSalon model);
}