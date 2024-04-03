using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public class WorkProgramRepository : IWorkProgramRepository
{
    private readonly IContext _context;

    public WorkProgramRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<WorkProgram>> GetWorkProgramsAsync()
    {
        var workPrograms = await _context.WorkPrograms.ToListAsync();

        return workPrograms;
    }

    public async Task<WorkProgram> GetWorkProgramAsync(Guid salonId)
    {
        var workProgram = await _context.WorkPrograms.FirstAsync(s => s.SalonId == salonId);

        return workProgram;
    }

    public async Task DeleteWorkProgramAsync(Guid salonId)
    {
        var workProgram = await _context.WorkPrograms.FirstAsync(s => s.SalonId == salonId);

        _context.WorkPrograms.Remove(workProgram);

        await _context.SaveChangesAsync();
    }

    public async Task CreateWorkProgramAsync(WorkProgram model)
    {
        await _context.WorkPrograms.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}