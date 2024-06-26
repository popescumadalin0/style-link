﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class HairStylistService
{
    public Guid Id { get; set; }

    [Required]
    public User User { get; set; }

    public Guid ServiceId { get; set; }
    [Required]
    public Service Service { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public TimeOnly Time { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}