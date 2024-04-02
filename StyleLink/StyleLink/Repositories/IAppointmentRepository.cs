using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StyleLink.Models;

namespace StyleLink.Repositories;

public interface IAppointmentRepository
{
    Task<List<AppointmentModel>> GetAppointmentsAsync();

    Task<AppointmentModel> GetAppointmentAsync(Guid id);

    Task DeleteAppointmentAsync(AppointmentModel model);

    Task CreateAppointmentAsync(AppointmentModel model);

    Task UpdateAppointmentAsync(AppointmentModel model);
}