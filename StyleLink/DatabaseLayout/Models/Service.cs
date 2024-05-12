using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Service
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ServiceTypeName { get; set; }
    [Required]
    public ServiceType ServiceType { get; set; }

    public ICollection<HairStylistService> HairStylistServices { get; set; } = new List<HairStylistService>();
}