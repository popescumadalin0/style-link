using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout;

public class Context : DbContext, IContext
{
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

        modelBuilder.Entity<Appointment>().Navigation(a => a.HairStylistSalonService).AutoInclude();
        //modelBuilder.Entity<Appointment>().Navigation(a => a.User).AutoInclude();

        modelBuilder.Entity<Favorite>().Navigation(f => f.Salon).AutoInclude();
        // modelBuilder.Entity<Favorite>().Navigation(f => f.User).AutoInclude();


        modelBuilder.Entity<HairStylist>().Navigation(h => h.HairStylistSalons).AutoInclude();
        modelBuilder.Entity<HairStylist>().Navigation(h => h.Services).AutoInclude();

        //modelBuilder.Entity<HairStylistSalonService>().Navigation(hsss => hsss.Appointments).AutoInclude();
        //modelBuilder.Entity<HairStylistSalonService>().Navigation(hsss => hsss.HairStylistSalon).AutoInclude();
        modelBuilder.Entity<HairStylistSalonService>().Navigation(hsss => hsss.Service).AutoInclude();


        //modelBuilder.Entity<Salon>().Navigation(s => s.Favorites).AutoInclude();
        modelBuilder.Entity<Salon>().Navigation(s => s.HairStylistSalons).AutoInclude();
        modelBuilder.Entity<Salon>().Navigation(s => s.SalonImages).AutoInclude();
        modelBuilder.Entity<Salon>().Navigation(s => s.WorkProgram).AutoInclude();

        //modelBuilder.Entity<SalonImage>().Navigation(si => si.Salon).AutoInclude();

        modelBuilder.Entity<Service>().Navigation(s => s.ServiceType).AutoInclude();

        //modelBuilder.Entity<WorkProgram>().Navigation(wp => wp.Salon).AutoInclude();

        //modelBuilder.Entity<HairStylistSalon>().Navigation(hss => hss.Salon).AutoInclude();
        modelBuilder.Entity<HairStylistSalon>().Navigation(hss => hss.HairStylist).AutoInclude();
        modelBuilder.Entity<HairStylistSalon>().Navigation(hss => hss.HairStylistSalonServices).AutoInclude();
    }
}