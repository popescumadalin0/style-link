using System;
using StyleLink.Enums;

namespace StyleLink.Models;

public class AppointmentModel
{
    public Guid Id { get; set; }

    public AppointmentStatus AppointmentStatus { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string ServiceType { get; set; }

    public string HairStyleName { get; set; }

    public string SalonName { get; set; }

    public int ServicePrice { get; set; }

    public string Currency { get; set; }
}