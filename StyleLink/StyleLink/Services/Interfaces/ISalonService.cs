using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface ISalonService
{
    Task<List<SalonModel>> GetSalonsAsync();

    Task<SalonDetailModel> GetSalonDetailsAsync(Guid id);

    Task AddSalonAsync(AddSalonModel model);
}