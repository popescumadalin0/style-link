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

    public byte[] ProfileImage { get; set; } = default!;

    public string ProfileImageName { get; set; } = default!;

    public string ProfileImageFileName { get; set; } = default!;

    [Required]
    public virtual WorkProgram WorkProgram { get; set; } = new WorkProgram();

    public ICollection<SalonImage> SalonImages { get; set; } = new List<SalonImage>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}