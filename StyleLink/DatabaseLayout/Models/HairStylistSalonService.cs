﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class HairStylistSalonService
{
    public Guid Id { get; set; }

    [Required]
    public Service Service { get; set; }

    [Required] public HairStylistSalon HairStylistSalon { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public TimeOnly Time { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}