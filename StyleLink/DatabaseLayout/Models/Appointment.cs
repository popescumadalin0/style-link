using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using StyleLink.Enums;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Appointment
{
    public Guid Id { get; set; }

    public AppointmentStatus Status { get; set; }

    public DateTime StartDate { get; set; }

    [Required]
    public User User { get; set; }

    [Required]
    public HairStylistSalonService HairStylistSalonService { get; set; } = new();
}