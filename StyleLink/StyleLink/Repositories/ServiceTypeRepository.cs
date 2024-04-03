using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public class ServiceTypeRepository : IServiceTypeRepository
{
    private readonly IContext _context;

    public ServiceTypeRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<ServiceType>> GetServiceTypesAsync()
    {
        var serviceTypes = await _context.ServiceTypes.ToListAsync();

        return serviceTypes;
    }

    public async Task<ServiceType> GetServiceTypeAsync(string name)
    {
        var serviceType = await _context.ServiceTypes.FirstAsync(s => s.Name == name);

        return serviceType;
    }

    public async Task DeleteServiceTypeAsync(string name)
    {
        var serviceType = await _context.ServiceTypes.FirstAsync(s => s.Name == name);

        _context.ServiceTypes.Remove(serviceType);

        await _context.SaveChangesAsync();
    }

    public async Task CreateServiceTypeAsync(ServiceType model)
    {
        await _context.ServiceTypes.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}