using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using StyleLink.Repositories.Interfaces;

namespace StyleLink.Repositories;

public class HairStylistRepository : IHairStylistRepository
{
    private readonly IContext _context;

    public HairStylistRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<HairStylist>> GetHairStylistsAsync()
    {
        var hairStylists = await _context.HairStylists.ToListAsync();

        return hairStylists;
    }

    public async Task<HairStylist> GetHairStylistAsync(Guid id)
    {
        var hairStylist = await _context.HairStylists.FirstAsync(s => s.Id == id);

        return hairStylist;
    }

    public async Task DeleteHairStylistAsync(Guid id)
    {
        var hairStylist = await _context.HairStylists.FirstAsync(s => s.Id == id);

        _context.HairStylists.Remove(hairStylist);

        await _context.SaveChangesAsync();
    }

    public async Task CreateHairStylistAsync(HairStylist model)
    {
        await _context.HairStylists.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}