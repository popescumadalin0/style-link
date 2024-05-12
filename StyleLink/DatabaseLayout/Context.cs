using DatabaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayout;

public class Context : IdentityDbContext<User, Role, Guid>, IContext
{
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<HairStylistService> HairStylistServices { get; set; }
    public DbSet<Salon> Salons { get; set; }
    public DbSet<SalonImage> SalonImages { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<WorkProgram> WorkPrograms { get; set; }
    public DbSet<SalonUser> SalonUsers { get; set; }

    public Context(DbContextOptions<Context> options)
        : base(options) { }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(name: "Users");
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable(name: "Roles");
        });
        modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
        {
            entity.ToTable(name: "UserClaims");
        });
        modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
        {
            entity.ToTable(name: "UserRoles");
        });
        modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity =>
        {
            entity.ToTable(name: "RoleClaims");
        });
        modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
        {
            entity.ToTable(name: "UserTokens");
        });
        modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
        {
            entity.ToTable(name: "UserLogins");
        });

        modelBuilder.Entity<Favorite>().HasOne(x => x.User)
            .WithMany(x => x.Favorites).OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<Favorite>().HasOne(x => x.Salon)
            .WithMany(x => x.Favorites).OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(x => x.SalonId);

        modelBuilder.Entity<HairStylistService>().HasOne(x => x.Service)
            .WithMany(x => x.HairStylistServices).OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(x => x.ServiceId);

        modelBuilder.Entity<Service>().HasOne(x => x.ServiceType)
            .WithMany(x => x.Services).OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(x => x.ServiceTypeName);

        modelBuilder.Entity<SalonImage>().HasOne(x => x.Salon)
            .WithMany(x => x.SalonImages).OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(x => x.SalonId);

        modelBuilder.Entity<SalonUser>()
            .HasOne(sc => sc.Salon)
            .WithMany(s => s.SalonUsers)
            .HasForeignKey(sc => sc.SalonId);


        modelBuilder.Entity<SalonUser>()
            .HasOne(sc => sc.User)
            .WithMany(s => s.SalonUsers)
            .HasForeignKey(sc => sc.UserId);

        modelBuilder.Entity<ServiceType>().Navigation(st => st.Services).AutoInclude();

        modelBuilder.Entity<Appointment>().HasOne(
            e => e.User)
            .WithMany(e => e.Appointments)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Appointment>().Navigation(a => a.Salon).AutoInclude();

        modelBuilder.Entity<Favorite>().Navigation(f => f.Salon).AutoInclude();

        modelBuilder.Entity<User>().Navigation(h => h.HairStylistServices).AutoInclude();

        modelBuilder.Entity<HairStylistService>().Navigation(h => h.Service).AutoInclude();

        modelBuilder.Entity<Salon>().Navigation(s => s.SalonUsers).AutoInclude();
        modelBuilder.Entity<SalonUser>().Navigation(s => s.User).AutoInclude();
        modelBuilder.Entity<Salon>().Navigation(s => s.SalonImages).AutoInclude();
        modelBuilder.Entity<Salon>().Navigation(s => s.WorkProgram).AutoInclude();

        modelBuilder.Entity<Service>().Navigation(s => s.ServiceType).AutoInclude();
    }
}