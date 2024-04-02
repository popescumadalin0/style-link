using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout;
using Microsoft.EntityFrameworkCore;
using StyleLink.Models;

namespace StyleLink.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly IContext _context;

    public AppointmentRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<AppointmentModel>> GetAppointmentsAsync()
    {
        var appointments = await _context.Appointments.ToListAsync();

        var appointmentsDto = appointments.Select(a => new AppointmentModel()
        {
            AppointmentStatus = a.Status,
            Currency = a.HairStylistSalonService?.Service.Currency,
            EndDate = a.StartDate.AddTicks(a.HairStylistSalonService?.Service.Time.Ticks ?? 0),
            StartDate = a.StartDate,
            HairStylistName = a.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName + a.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName,
            Id = a.Id,
            SalonName = a.HairStylistSalonService?.HairStylistSalon.Salon.Name,
            ServicePrice = a.HairStylistSalonService?.Service.Price ?? 0,
            ServiceType = a.HairStylistSalonService?.Service.ServiceType.Name,
        });

        return appointmentsDto.ToList();
    }

    public Task<AppointmentModel> GetAppointmentAsync(Guid id)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteAppointmentAsync(AppointmentModel model)
    {
        throw new System.NotImplementedException();
    }

    public Task CreateAppointmentAsync(AppointmentModel model)
    {
        throw new System.NotImplementedException();
    }

    public Task UpdateAppointmentAsync(AppointmentModel model)
    {
        throw new System.NotImplementedException();
    }
}