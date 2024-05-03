using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Name))]
public class Role : IdentityRole
{
    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();

    [Required] public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
}