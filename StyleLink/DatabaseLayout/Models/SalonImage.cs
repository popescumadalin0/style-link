using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class SalonImage
{
    public Guid Id { get; set; }

    public byte[] Content { get; set; }

    public string Name { get; set; }

    public string FileName { get; set; }

    public Guid SalonId { get; set; }

    public Salon Salon { get; set; }
}