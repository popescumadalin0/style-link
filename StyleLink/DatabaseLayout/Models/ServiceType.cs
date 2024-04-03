using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Name))]
public class ServiceType
{
    public string Name { get; set; }

    public ICollection<Service> Services { get; set; } = new List<Service>();
}