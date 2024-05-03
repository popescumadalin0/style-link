using Microsoft.EntityFrameworkCore;

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

    public virtual ICollection<Salon> Salons { get; set; } = new List<Salon>();

    public ICollection<HairStylistService> HairStylistServices { get; set; } = new List<HairStylistService>();
}