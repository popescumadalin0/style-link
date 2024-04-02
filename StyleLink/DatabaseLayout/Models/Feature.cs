using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Feature
{
    public Guid Id { get; set; }

    public string HTMLFlag { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
}