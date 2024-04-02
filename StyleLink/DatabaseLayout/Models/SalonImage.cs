using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class SalonImage
{
    public Guid Id { get; set; }

    public string Content { get; set; }

    public Salon Salon { get; set; }
}