using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout;

public class Context : DbContext, IContext
{
    public Context(DbContextOptions options)
        : base(options) { }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<HairStylist> HairStylists { get; set; }
    public DbSet<HairStylistSalonService> HairStylistSalonServices { get; set; }
    public DbSet<Salon> Salons { get; set; }
    public DbSet<SalonImage> SalonImages { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<WorkProgram> WorkPrograms { get; set; }
    public DbSet<HairStylistSalon> HairStylistSalons { get; set; }
}