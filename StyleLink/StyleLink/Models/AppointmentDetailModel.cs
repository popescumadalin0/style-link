using System;
using StyleLink.Enums;

namespace StyleLink.Models;

public class AppointmentDetailModel
{
    public Guid Id { get; set; }

    public AppointmentStatus AppointmentStatus { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string ServiceType { get; set; }

    public string HairStylistName { get; set; }

    public string SalonName { get; set; }

    public string SalonId { get; set; }

    public int ServicePrice { get; set; }

    public string Currency { get; set; }

    public int UserRating { get; set; } = 0;

    public string SalonAddress { get; set; }

    public string SalonPhoneNumber { get; set; }

    public string MapsUrl { get; set; }
}