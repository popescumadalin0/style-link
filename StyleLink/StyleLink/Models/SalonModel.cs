using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace StyleLink.Models;

public class SalonModel
{
    public Guid Id { get; set; }

    public int NumberOfEvaluations { get; set; }

    public double SalonRating { get; set; }

    public string SalonName { get; set; }

    public string Address { get; set; }

    public ICollection<IFormFile> Images { get; set; }

    public IFormFile ProfileImage { get; set; }
}