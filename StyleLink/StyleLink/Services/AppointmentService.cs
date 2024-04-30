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
            Currency = a.HairStylistSalonService?.Currency,
            EndDate = a.StartDate.AddTicks(a.HairStylistSalonService?.Time.Ticks ?? 0),
            StartDate = a.StartDate,
            HairStylistName = a.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName + " " + a.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName,
            Id = a.Id,
            SalonName = a.HairStylistSalonService?.HairStylistSalon.Salon.Name,
            ServicePrice = a.HairStylistSalonService?.Price ?? 0,
            ServiceType = a.HairStylistSalonService?.Service.ServiceType.Name,
        }).ToList();

        return appointmentsDto;
    }

    public async Task<AppointmentDetailModel> GetAppointmentDetailsAsync(Guid id)
    {
        var appointment = await _appointmentRepository.GetAppointmentAsync(id);

        var appointmentDto = new AppointmentDetailModel()
        {
            StartDate = appointment.StartDate,
            ServiceType = appointment.HairStylistSalonService.Service.ServiceType.Name,
            Currency = appointment.HairStylistSalonService.Currency,
            AppointmentStatus = appointment.Status,
            EndDate = appointment.StartDate.AddTicks(appointment.HairStylistSalonService?.Time.Ticks ?? 0),
            HairStylistName = appointment.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName +
                              appointment.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName,
            Id = appointment.Id,
            MapsUrl = appointment.HairStylistSalonService.HairStylistSalon.Salon.GoogleMapsAddress,
            SalonAddress = appointment.HairStylistSalonService.HairStylistSalon.Salon.Address,
            SalonId = appointment.HairStylistSalonService.HairStylistSalon.Salon.Id,
            SalonName = appointment.HairStylistSalonService.HairStylistSalon.Salon.Name,
            SalonPhoneNumber = appointment.HairStylistSalonService.HairStylistSalon.HairStylist.PhoneNumber,
            ServicePrice = appointment.HairStylistSalonService.Price,
            UserRating = appointment.HairStylistSalonService.HairStylistSalon.Salon.Rating,
        };

        return appointmentDto;
    }
}