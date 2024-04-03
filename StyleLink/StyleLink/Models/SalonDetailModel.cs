using System;
using System.Collections.Generic;

namespace StyleLink.Models;

public class SalonDetailModel
{
    public Guid Id { get; set; }

    public string SalonAddress { get; set; }

    public string SalonName { get; set; }

    public string MapsUrl { get; set; }

    public List<string> ImagesTest { get; set; }

    public string ProfileImageTest { get; set; }

    //todo
    public List<byte[]> Images { get; set; }

    public byte[] ProfileImage { get; set; }

    public List<ServiceModel> Services { get; set; }

    public List<HairStylistModel> HairStylists { get; set; }

    public TimeSchedule TimeSchedule { get; set; }

    public double SalonRating { get; set; }

    public int NumberOfEvaluations { get; set; }
}