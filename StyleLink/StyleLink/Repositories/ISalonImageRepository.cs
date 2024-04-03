using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface ISalonImageRepository
{
    Task<List<SalonImage>> GetSalonImagesAsync();

    Task<SalonImage> GetSalonImageAsync(Guid id);

    Task DeleteSalonImageAsync(Guid id);

    Task CreateSalonImageAsync(SalonImage model);
}