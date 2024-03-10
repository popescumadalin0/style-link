using System.Collections.Generic;

namespace StyleLink.Models;

public class FavoriteModel
{
    public int NumberOfEvaluations { get; set; }

    public double SalonRating { get; set; }

    public string SalonName { get; set; }

    public string Address { get; set; }

    public List<string> ImagesTest { get; set; } = new();
    public List<byte[]> Images { get; set; } = new();
}