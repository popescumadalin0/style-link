using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Service
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    [Required]
    public ServiceType ServiceType { get; set; }

    public virtual ICollection<HairStylist> HairStylists { get; set; } = new List<HairStylist>();

    public ICollection<HairStylistSalonService> HairStylistSalonServices { get; set; } = new List<HairStylistSalonService>();
}