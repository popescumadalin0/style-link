using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public class HairStylistSalonServiceRepository : IHairStylistSalonServiceRepository
{
    private readonly IContext _context;

    public HairStylistSalonServiceRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<HairStylistSalonService>> GetHairStylistSalonServicesAsync()
    {
        var hairStylistHairStylistSalonServiceServices = await _context.HairStylistSalonServices.ToListAsync();

        return hairStylistHairStylistSalonServiceServices;
    }

    public async Task<HairStylistSalonService> GetHairStylistSalonServiceAsync(Guid id)
    {
        var hairStylistHairStylistSalonServiceService = await _context.HairStylistSalonServices.FirstAsync(s => s.Id == id);

        return hairStylistHairStylistSalonServiceService;
    }

    public async Task DeleteHairStylistSalonServiceAsync(Guid id)
    {
        var hairStylistHairStylistSalonServiceService = await _context.HairStylistSalonServices.FirstAsync(s => s.Id == id);

        _context.HairStylistSalonServices.Remove(hairStylistHairStylistSalonServiceService);

        await _context.SaveChangesAsync();
    }

    public async Task CreateHairStylistSalonServiceAsync(HairStylistSalonService model)
    {
        await _context.HairStylistSalonServices.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}