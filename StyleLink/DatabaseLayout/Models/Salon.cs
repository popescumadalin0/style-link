using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Salon
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int ReviewCount { get; set; }

    public string Address { get; set; }

    public double Rating { get; set; }

    public string GoogleMapsAddress { get; set; }

    public string? ProfileImage { get; set; } = default!;

    [Required]
    public virtual WorkProgram WorkProgram { get; set; }

    public ICollection<SalonImage> SalonImages { get; set; } = default!;

    public ICollection<HairStylistSalon> HairStylistSalons { get; set; }

    public ICollection<Favorite> Favorites { get; set; }
}