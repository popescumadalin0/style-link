using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public interface IWorkProgramRepository
{
    Task<List<WorkProgram>> GetWorkProgramsAsync();

    Task<WorkProgram> GetWorkProgramAsync(Guid salonId);

    Task DeleteWorkProgramAsync(Guid salonId);

    Task CreateWorkProgramAsync(WorkProgram model);
}