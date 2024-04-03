using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface IHairStylistSalonServiceRepository
{
    Task<List<HairStylistSalonService>> GetHairStylistSalonServicesAsync();

    Task<HairStylistSalonService> GetHairStylistSalonServiceAsync(Guid id);

    Task DeleteHairStylistSalonServiceAsync(Guid id);

    Task CreateHairStylistSalonServiceAsync(HairStylistSalonService model);
}