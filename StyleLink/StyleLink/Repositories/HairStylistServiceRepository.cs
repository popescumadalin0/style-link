using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Repositories;

public class HairStylistServiceRepository : IHairStylistServiceRepository
{
    private readonly IContext _context;

    public HairStylistServiceRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<HairStylistService>> GetHairStylistServicesAsync()
    {
        var hairStylistSalons = await _context.HairStylistServices.ToListAsync();

        return hairStylistSalons;
    }

    public async Task<HairStylistService> GetHairStylistServiceAsync(Guid id)
    {
        var hairStylistSalon = await _context.HairStylistServices.FirstAsync(s => s.Id == id);

        return hairStylistSalon;
    }

    public async Task DeleteHairStylistServiceAsync(Guid id)
    {
        var hairStylistSalon = await _context.HairStylistServices.FirstAsync(s => s.Id == id);

        _context.HairStylistServices.Remove(hairStylistSalon);

        await _context.SaveChangesAsync();
    }

    public async Task CreateHairStylistServiceAsync(HairStylistService model)
    {
        await _context.HairStylistServices.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}