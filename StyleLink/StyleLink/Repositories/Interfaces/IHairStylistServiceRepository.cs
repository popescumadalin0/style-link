using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IHairStylistServiceRepository
{
    Task<List<HairStylistService>> GetHairStylistServicesAsync();

    Task<HairStylistService> GetHairStylistServiceAsync(Guid id);

    Task DeleteHairStylistServiceAsync(Guid id);

    Task CreateHairStylistServiceAsync(HairStylistService model);
}