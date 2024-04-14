using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface ISalonImageRepository
{
    Task<List<SalonImage>> GetSalonImagesAsync();

    Task<SalonImage> GetSalonImageAsync(Guid id);

    Task DeleteSalonImageAsync(Guid id);

    Task CreateSalonImageAsync(SalonImage model);
}