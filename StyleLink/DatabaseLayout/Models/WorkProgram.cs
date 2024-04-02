using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(SalonId))]
public class WorkProgram
{
    [ForeignKey("Salon")]
    public Guid SalonId { get; set; }

    [Required]
    public virtual Salon Salon { get; set; }

    public string Monday { get; set; }

    public string Tuesday { get; set; }

    public string Wednesday { get; set; }

    public string Thursday { get; set; }

    public string Friday { get; set; }

    public string Saturday { get; set; }

    public string Sunday { get; set; }
}