using System;
using StyleLink.Enums;

namespace StyleLink.Models;

public class AppointmentDetailModel
{
    public Guid Id { get; set; }

    public AppointmentStatus AppointmentStatus { get; set; }

    public DateTime StartDate { get; set; }

    public string ServiceType { get; set; }

    public string HairStyleName { get; set; }

    public string SalonName { get; set; }

    public int ServicePrice { get; set; }

    public string Currency { get; set; }

    public int Rating { get; set; } = 0;

    public string Address { get; set; }

    public string SalonPhoneNumber { get; set; }

    public string MapsUrl { get; set; }
}