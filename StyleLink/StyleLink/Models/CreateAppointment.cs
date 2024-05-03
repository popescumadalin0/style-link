using System;
using System.ComponentModel.DataAnnotations;

namespace StyleLink.Models;

public class CreateAppointment
{
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public string HairStylistId { get; set; }

    public string ServiceId { get; set; }
}