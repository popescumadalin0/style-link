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
    private readonly IServiceTypeRepository _serviceTypeRepository;

    public ServiceSalonService(IServiceRepository serviceSalonRepository, IServiceTypeRepository serviceTypeRepository)
    {
        _serviceSalonRepository = serviceSalonRepository;
        _serviceTypeRepository = serviceTypeRepository;
    }

    public async Task<List<AddServiceModel>> GetAddServicesAsync()
    {
        var serviceSalons = await _serviceSalonRepository.GetServicesAsync();

        var serviceSalonsDto = serviceSalons.Select(s => new AddServiceModel()
        {
            Id = s.Id,
            Name = s.Name,
            ServiceType = s.ServiceType.Name,
        }).ToList();

        return serviceSalonsDto;
    }

    public async Task AddServiceAsync(AddServiceModel model)
    {
        var serviceType = await _serviceTypeRepository.GetServiceTypeAsync(model.ServiceType);
        var service = new Service()
        {
            Name = model.Name,
            ServiceType = serviceType,
            Id = Guid.NewGuid(),
        };

        await _serviceSalonRepository.CreateServiceAsync(service);
    }
}