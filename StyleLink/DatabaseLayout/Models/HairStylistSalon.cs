using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class HairStylistSalon
{
    public Guid Id { get; set; }

    [Required]
    public HairStylist HairStylist { get; set; }

    [Required]
    public Salon Salon { get; set; }

    public ICollection<HairStylistSalonService> HairStylistSalonServices { get; set; }
}