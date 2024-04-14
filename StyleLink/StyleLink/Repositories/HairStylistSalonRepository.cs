using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Repositories;

public class HairStylistSalonRepository : IHairStylistSalonRepository
{
    private readonly IContext _context;

    public HairStylistSalonRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<HairStylistSalon>> GetHairStylistSalonsAsync()
    {
        var hairStylistSalons = await _context.HairStylistSalons.ToListAsync();

        return hairStylistSalons;
    }

    public async Task<HairStylistSalon> GetHairStylistSalonAsync(Guid id)
    {
        var hairStylistSalon = await _context.HairStylistSalons.FirstAsync(s => s.Id == id);

        return hairStylistSalon;
    }

    public async Task DeleteHairStylistSalonAsync(Guid id)
    {
        var hairStylistSalon = await _context.HairStylistSalons.FirstAsync(s => s.Id == id);

        _context.HairStylistSalons.Remove(hairStylistSalon);

        await _context.SaveChangesAsync();
    }

    public async Task CreateHairStylistSalonAsync(HairStylistSalon model)
    {
        await _context.HairStylistSalons.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}