using System;
using System.Collections.Generic;
using StyleLink.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<AppointmentModel>> GetAppointmentsAsync()
    {
        var appointments = await _appointmentRepository.GetAppointmentsAsync();
        var appointmentsDto = appointments.Select(a => new AppointmentModel()
        {
            AppointmentStatus = a.Status,
            Currency = a.HairStylistService?.Currency,
            EndDate = a.StartDate.AddTicks(a.HairStylistService?.Time.Ticks ?? 0),
            StartDate = a.StartDate,
            HairStylistName = a.HairStylistService?.HairStylist.FirstName + " " + a.HairStylistService?.HairStylist.LastName,
            Id = a.Id,
            SalonName = a.Salon.Name,
            ServicePrice = a.HairStylistService?.Price ?? 0,
            ServiceType = a.HairStylistService?.Service.ServiceType.Name,
        }).ToList();

        return appointmentsDto;
    }

    public async Task<AppointmentDetailModel> GetAppointmentDetailsAsync(Guid id)
    {
        var appointment = await _appointmentRepository.GetAppointmentAsync(id);

        var appointmentDto = new AppointmentDetailModel()
        {
            StartDate = appointment.StartDate,
            ServiceType = appointment.HairStylistService.Service.ServiceType.Name,
            Currency = appointment.HairStylistService.Currency,
            AppointmentStatus = appointment.Status,
            EndDate = appointment.StartDate.AddTicks(appointment.HairStylistService?.Time.Ticks ?? 0),
            HairStylistName = appointment.HairStylistService?.HairStylist.FirstName +
                              appointment.HairStylistService?.HairStylist.LastName,
            Id = appointment.Id,
            MapsUrl = appointment.Salon.GoogleMapsAddress,
            SalonAddress = appointment.Salon.Address,
            SalonId = appointment.Salon.Id,
            SalonName = appointment.Salon.Name,
            SalonPhoneNumber = appointment.HairStylistService.HairStylist.PhoneNumber,
            ServicePrice = appointment.HairStylistService.Price,
            UserRating = appointment.Salon.Rating,
        };

        return appointmentDto;
    }
}