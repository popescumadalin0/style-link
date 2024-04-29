using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public virtual ICollection<HairStylist> HairStylists { get; set; } = new List<HairStylist>();

    public ICollection<HairStylistSalonService> HairStylistSalonServices { get; set; } = new List<HairStylistSalonService>();
}