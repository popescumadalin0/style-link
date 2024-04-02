using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class Favorite
{
    public Guid Id { get; set; }

    [Required]
    public User User { get; set; }

    [Required]
    public Salon Salon { get; set; }
}