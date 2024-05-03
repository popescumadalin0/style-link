using System;
using System.Collections.Generic;

namespace StyleLink.Models;

public class SalonDetailModel
{
    public Guid Id { get; set; }

    public string SalonAddress { get; set; }

    public string SalonName { get; set; }

    public string MapsUrl { get; set; }

    public ICollection<string> Images { get; set; }

    public string ProfileImage { get; set; }

    public List<ServiceModel> Services { get; set; }

    public List<HairStylistModel> HairStylists { get; set; }

    public TimeSchedule TimeSchedule { get; set; }

    public double SalonRating { get; set; }

    public int NumberOfEvaluations { get; set; }

    public CreateAppointment CreateAppointment { get; set; }
}