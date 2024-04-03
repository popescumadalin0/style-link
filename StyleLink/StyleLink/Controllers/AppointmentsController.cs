using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StyleLink.Models;
using StyleLink.Repositories;

namespace StyleLink.Controllers;

public class AppointmentsController : Controller
{
    private readonly ILogger<AppointmentsController> _logger;

    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentsController(
        ILogger<AppointmentsController> logger,
        IAppointmentRepository appointmentRepository)
    {
        _logger = logger;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<IActionResult> AppointmentsAsync()
    {
        var appointments = await _appointmentRepository.GetAppointmentsAsync();
        var appointmentsDto = appointments.Select(a => new AppointmentModel()
        {
            AppointmentStatus = a.Status,
            Currency = a.HairStylistSalonService?.Service.Currency,
            EndDate = a.StartDate.AddTicks(a.HairStylistSalonService?.Service.Time.Ticks ?? 0),
            StartDate = a.StartDate,
            HairStylistName = a.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName + " " + a.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName,
            Id = a.Id,
            SalonName = a.HairStylistSalonService?.HairStylistSalon.Salon.Name,
            ServicePrice = a.HairStylistSalonService?.Service.Price ?? 0,
            ServiceType = a.HairStylistSalonService?.Service.ServiceType.Name,
        }).ToList();
        return View(appointmentsDto);
    }

    [HttpGet]
    public async Task<IActionResult> AppointmentDetailsAsync(Guid id)
    {
        var appointment = await _appointmentRepository.GetAppointmentAsync(id);

        var appointmentDto = new AppointmentDetailModel()
        {
            StartDate = appointment.StartDate,
            ServiceType = appointment.HairStylistSalonService.Service.ServiceType.Name,
            Currency = appointment.HairStylistSalonService.Service.Currency,
            AppointmentStatus = appointment.Status,
            EndDate = appointment.StartDate.AddTicks(appointment.HairStylistSalonService?.Service.Time.Ticks ?? 0),
            HairStylistName = appointment.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName +
                              appointment.HairStylistSalonService?.HairStylistSalon.HairStylist.FirstName,
            Id = appointment.Id,
            MapsUrl = appointment.HairStylistSalonService.HairStylistSalon.Salon.GoogleMapsAddress,
            SalonAddress = appointment.HairStylistSalonService.HairStylistSalon.Salon.Address,
            SalonId = appointment.HairStylistSalonService.HairStylistSalon.Salon.Id,
            SalonName = appointment.HairStylistSalonService.HairStylistSalon.Salon.Name,
            SalonPhoneNumber = appointment.HairStylistSalonService.HairStylistSalon.HairStylist.PhoneNumber,
            ServicePrice = appointment.HairStylistSalonService.Service.Price,
            UserRating = appointment.HairStylistSalonService.HairStylistSalon.Salon.Rating,
        };

        return View(appointmentDto);
    }
}