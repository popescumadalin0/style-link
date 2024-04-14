using System;
using System.Collections.Generic;
using StyleLink.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Services;

public class ServiceSalonService : IServiceSalonService
{
    private readonly IServiceRepository _serviceSalonRepository;

    public ServiceSalonService(IServiceRepository serviceSalonRepository)
    {
        _serviceSalonRepository = serviceSalonRepository;
    }

    public async Task<List<AddServiceModel>> GetAddServicesAsync()
    {
        var serviceSalons = await _serviceSalonRepository.GetServicesAsync();

        var serviceSalonsDto = serviceSalons.Select(s => new AddServiceModel()
        {
            Id = s.Id,
            Currency = s.Currency,
            Name = s.Name,
            ServiceType = new ServiceTypeModel() { Name = s.ServiceType.Name },
            Price = s.Price,
            Time = s.Time
        }).ToList();

        return serviceSalonsDto;
    }

    public async Task AddServiceAsync(AddServiceModel model)
    {
        var service = new Service()
        {
            Currency = model.Currency,
            Name = model.Name,
            Price = model.Price,
            ServiceType = new ServiceType() { Name = model.ServiceType.Name },
            Time = model.Time,
            Id = Guid.NewGuid(),
        };

        await _serviceSalonRepository.CreateServiceAsync(service);
    }
}