using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace StyleLink.Models;

public class FavoriteModel
{
    public Guid Id { get; set; }

    public int NumberOfEvaluations { get; set; }

    public double SalonRating { get; set; }

    public string SalonName { get; set; }

    public Guid SalonId { get; set; }

    public string Address { get; set; }

    public ICollection<string> Images { get; set; }

    public string ProfileImage { get; set; }
}