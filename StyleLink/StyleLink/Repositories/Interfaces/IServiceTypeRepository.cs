using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IServiceTypeRepository
{
    Task<List<ServiceType>> GetServiceTypesAsync();

    Task<ServiceType> GetServiceTypeAsync(string name);

    Task DeleteServiceTypeAsync(string name);

    Task CreateServiceTypeAsync(ServiceType model);
}