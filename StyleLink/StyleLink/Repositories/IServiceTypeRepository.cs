using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface IServiceTypeRepository
{
    Task<List<ServiceType>> GetServiceTypesAsync();

    Task<ServiceType> GetServiceTypeAsync(string name);

    Task DeleteServiceTypeAsync(string name);

    Task CreateServiceTypeAsync(ServiceType model);
}