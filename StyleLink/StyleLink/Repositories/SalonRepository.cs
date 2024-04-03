using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public class SalonRepository : ISalonRepository
{
    private readonly IContext _context;

    public SalonRepository(IContext context)
    {
        _context = context;
    }

    public Task<List<Salon>> GetSalonsAsync()
    {
        var salons = _context.Salons.ToListAsync();

        return salons;
    }

    public Task<Salon> GetSalonAsync(Guid id)
    {
        var salon = _context.Salons.FirstAsync(s => s.Id == id);

        return salon;
    }

    public async Task DeleteSalonAsync(Guid id)
    {
        var salon = await _context.Salons.FirstAsync(s => s.Id == id);

        _context.Salons.Remove(salon);

        await _context.SaveChangesAsync();
    }

    public async Task CreateSalonAsync(Salon model)
    {
        await _context.Salons.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}