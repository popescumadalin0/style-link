using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class HairStylist
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public byte[] ProfileImage { get; set; } = default!;

    public string ProfileImageName { get; set; } = default!;

    public string ProfileImageFileName { get; set; } = default!;


    public string PhoneNumber { get; set; }

    [Required]
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    [Required] public ICollection<HairStylistSalon> HairStylistSalons { get; set; } = new List<HairStylistSalon>();
}