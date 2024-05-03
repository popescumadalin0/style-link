using DatabaseLayout.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout;

public class Context : IdentityDbContext<User>, IContext
{
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<HairStylist> HairStylists { get; set; }
    public DbSet<HairStylistService> HairStylistServices { get; set; }
    public DbSet<Salon> Salons { get; set; }
    public DbSet<SalonImage> SalonImages { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<WorkProgram> WorkPrograms { get; set; }

    public Context(DbContextOptions options)
        : base(options) { }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().Navigation(r => r.Features).AutoInclude();
        modelBuilder.Entity<Role>().Navigation(r => r.Users).AutoInclude();


        modelBuilder.Entity<ServiceType>().Navigation(st => st.Services).AutoInclude();

        //modelBuilder.Entity<Feature>().Navigation(f => f.Roles).AutoInclude();

        modelBuilder.Entity<User>().Navigation(u => u.Favorites).AutoInclude();
        modelBuilder.Entity<User>().Navigation(u => u.Appointments).AutoInclude();
        //modelBuilder.Entity<User>().Navigation(u => u.Role).AutoInclude();

        modelBuilder.Entity<Appointment>().Navigation(a => a.HairStylistService).AutoInclude();
        modelBuilder.Entity<Appointment>().Navigation(a => a.Salon).AutoInclude();

        //modelBuilder.Entity<Appointment>().Navigation(a => a.User).AutoInclude();

        modelBuilder.Entity<Favorite>().Navigation(f => f.Salon).AutoInclude();
        // modelBuilder.Entity<Favorite>().Navigation(f => f.User).AutoInclude();


        modelBuilder.Entity<HairStylist>().Navigation(h => h.HairStylistServices).AutoInclude();

        modelBuilder.Entity<HairStylistService>().Navigation(h => h.Service).AutoInclude();

        //modelBuilder.Entity<Salon>().Navigation(s => s.Favorites).AutoInclude();
        modelBuilder.Entity<Salon>().Navigation(s => s.HairStylists).AutoInclude();
        modelBuilder.Entity<Salon>().Navigation(s => s.SalonImages).AutoInclude();
        modelBuilder.Entity<Salon>().Navigation(s => s.WorkProgram).AutoInclude();

        //modelBuilder.Entity<SalonImage>().Navigation(si => si.Salon).AutoInclude();

        modelBuilder.Entity<Service>().Navigation(s => s.ServiceType).AutoInclude();

        //modelBuilder.Entity<WorkProgram>().Navigation(wp => wp.Salon).AutoInclude();
    }
}