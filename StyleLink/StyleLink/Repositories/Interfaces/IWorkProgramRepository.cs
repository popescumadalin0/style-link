using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IWorkProgramRepository
{
    Task<List<WorkProgram>> GetWorkProgramsAsync();

    Task<WorkProgram> GetWorkProgramAsync(Guid salonId);

    Task DeleteWorkProgramAsync(Guid salonId);

    Task CreateWorkProgramAsync(WorkProgram model);
}