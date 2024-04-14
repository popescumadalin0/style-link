using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface ISalonRepository
{
    Task<List<Salon>> GetSalonsAsync();

    Task<Salon> GetSalonAsync(Guid id);

    Task DeleteSalonAsync(Guid id);

    Task CreateSalonAsync(Salon model);
}