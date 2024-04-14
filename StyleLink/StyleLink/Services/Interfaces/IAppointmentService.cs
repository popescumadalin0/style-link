using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface IAppointmentService
{
    Task<List<AppointmentModel>> GetAppointmentsAsync();

    Task<AppointmentDetailModel> GetAppointmentDetailsAsync(Guid id);
}