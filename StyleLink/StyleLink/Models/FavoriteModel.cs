using System;
using System.Collections.Generic;

namespace StyleLink.Models;

public class FavoriteModel
{
    public Guid Id { get; set; }

    public int NumberOfEvaluations { get; set; }

    public double SalonRating { get; set; }

    public string SalonName { get; set; }

    public string SalonId { get; set; }

    public string Address { get; set; }

    public string ProfileImageTest { get; set; }

    public List<string> ImagesTest { get; set; } = new();

    //todo
    public List<byte[]> Images { get; set; } = new();

    public string ProfileImage { get; set; }
}