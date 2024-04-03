using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace StyleLink.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly IContext _context;

    public AppointmentRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<Appointment>> GetAppointmentsAsync()
    {
        var appointments = await _context.Appointments.ToListAsync();

        return appointments;
    }

    public async Task<Appointment> GetAppointmentAsync(Guid id)
    {
        var appointment = await _context.Appointments.FirstAsync(a => a.Id == id);

        return appointment;
    }

    public async Task DeleteAppointmentAsync(Guid id)
    {
        var appointment = await _context.Appointments.FirstAsync(a => a.Id == id);
        _context.Appointments.Remove(appointment);

        await _context.SaveChangesAsync();
    }

    public async Task CreateAppointmentAsync(Appointment model)
    {
        await _context.Appointments.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}