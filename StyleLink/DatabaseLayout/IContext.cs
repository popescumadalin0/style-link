using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout;

public interface IContext
{
    DbSet<ServiceType> ServiceTypes { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Appointment> Appointments { get; set; }
    DbSet<Favorite> Favorites { get; set; }
    DbSet<HairStylist> HairStylists { get; set; }
    DbSet<HairStylistService> HairStylistServices { get; set; }
    DbSet<Salon> Salons { get; set; }
    DbSet<SalonImage> SalonImages { get; set; }
    DbSet<Service> Services { get; set; }
    DbSet<WorkProgram> WorkPrograms { get; set; }

    Task<int> SaveChangesAsync();
}