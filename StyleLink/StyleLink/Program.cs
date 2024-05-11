using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StyleLink;
using StyleLink.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddServices(builder.Configuration);

builder.Services.AddIdentity<User, Role>(options =>
    {
        options.Password.RequireDigit = true;

        options.Password.RequireLowercase = true;

        options.Password.RequireUppercase = true;

        options.User.RequireUniqueEmail = true;

        options.Password.RequiredLength = 8;
    }).AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

await DefaultDataAsync();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

return;

async Task DefaultDataAsync()
{
    var roleManager = builder.Services.BuildServiceProvider().GetService<RoleManager<Role>>();
    var userManager = builder.Services.BuildServiceProvider().GetService<UserManager<User>>();
    var role = await roleManager.FindByNameAsync(Roles.User);
    if (role == null)
    {
        var result = await roleManager.CreateAsync(new Role()
        {
            Id = Guid.NewGuid(),
            Name = Roles.User
        });
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }
        result = await roleManager.CreateAsync(new Role()
        {
            Id = Guid.NewGuid(),
            Name = Roles.HairStylist
        });
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }
        result = await roleManager.CreateAsync(new Role()
        {
            Id = Guid.NewGuid(),
            Name = Roles.Administrator
        });
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }
    }

    var tryUser = await userManager.FindByNameAsync("admin@admin.ro");
    if (tryUser == null)
    {
        var user = new User()
        {
            ProfileImage = new byte[1],
            Email = "admin@admin.ro",
            LastName = "admin",
            Id = Guid.NewGuid(),
            EmailConfirmed = true,
            FirstName = "admin",
            PhoneNumberConfirmed = true,
            UserName = "admin@admin.ro",
            PhoneNumber = "0711111111",
            ProfileImageName = "admin",
            ProfileImageFileName = "admin.jpg"
        };

        var result = await userManager.CreateAsync(user, "Admin1234!");
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }

        result = await userManager.AddToRoleAsync(user, Roles.User);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }

        result = await userManager.AddToRoleAsync(user, Roles.HairStylist);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }

        result = await userManager.AddToRoleAsync(user, Roles.Administrator);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }
    }

}