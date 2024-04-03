using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly IContext _context;

    public ServiceRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<Service>> GetServicesAsync()
    {
        var services = await _context.Services.ToListAsync();

        return services;
    }

    public async Task<Service> GetServiceAsync(Guid id)
    {
        var service = await _context.Services.FirstAsync(s => s.Id == id);

        return service;
    }

    public async Task DeleteServiceAsync(Guid id)
    {
        var service = await _context.Services.FirstAsync(s => s.Id == id);

        _context.Services.Remove(service);

        await _context.SaveChangesAsync();
    }

    public async Task CreateServiceAsync(Service model)
    {
        await _context.Services.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}