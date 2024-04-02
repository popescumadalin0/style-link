using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Service
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public DateTime Time { get; set; }

    [Required]
    public ServiceType ServiceType { get; set; }

    public virtual ICollection<HairStylist> HairStylists { get; set; }

    public ICollection<HairStylistSalonService> HairStylistSalonServices { get; set; }
}