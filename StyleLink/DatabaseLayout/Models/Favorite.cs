﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Favorite
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    [Required]
    public User User { get; set; }

    public Guid SalonId { get; set; }

    [Required]
    public Salon Salon { get; set; }
}