using Microsoft.AspNetCore.Identity;

namespace DatabaseLayout.Models;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public byte[] ProfileImage { get; set; }

    public string ProfileImageFileName { get; set; }

    public string ProfileImageName { get; set; }

    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}