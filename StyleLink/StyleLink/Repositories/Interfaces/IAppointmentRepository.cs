using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace StyleLink.Repositories.Interfaces;

public interface IAppointmentRepository
{
    Task<List<Appointment>> GetAppointmentsAsync();

    Task<Appointment> GetAppointmentAsync(Guid id);

    Task DeleteAppointmentAsync(Guid id);

    Task CreateAppointmentAsync(Appointment model);
}