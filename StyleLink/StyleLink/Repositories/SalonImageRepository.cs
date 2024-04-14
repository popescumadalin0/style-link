using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Repositories;

public class SalonImageRepository : ISalonImageRepository
{
    private readonly IContext _context;

    public SalonImageRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<SalonImage>> GetSalonImagesAsync()
    {
        var salonImages = await _context.SalonImages.ToListAsync();

        return salonImages;
    }

    public async Task<SalonImage> GetSalonImageAsync(Guid id)
    {
        var salonImage = await _context.SalonImages.FirstAsync(s => s.Id == id);

        return salonImage;
    }

    public async Task DeleteSalonImageAsync(Guid id)
    {
        var salonImage = await _context.SalonImages.FirstAsync(s => s.Id == id);

        _context.SalonImages.Remove(salonImage);

        await _context.SaveChangesAsync();
    }

    public async Task CreateSalonImageAsync(SalonImage model)
    {
        await _context.SalonImages.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}