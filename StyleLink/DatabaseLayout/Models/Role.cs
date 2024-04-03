using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Name))]
public class Role
{
    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();

    [Required] public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
}