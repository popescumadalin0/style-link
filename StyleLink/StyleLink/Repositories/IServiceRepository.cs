using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface IServiceRepository
{
    Task<List<Service>> GetServicesAsync();

    Task<Service> GetServiceAsync(Guid id);

    Task DeleteServiceAsync(Guid id);

    Task CreateServiceAsync(Service model);
}