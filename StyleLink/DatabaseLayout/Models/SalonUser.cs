using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class SalonUser
{
    public Guid Id { get; set; }

    public Guid SalonId { get; set; }

    public Salon Salon { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
}