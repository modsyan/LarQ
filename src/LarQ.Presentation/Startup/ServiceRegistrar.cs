using ChustaSoft.Services.StaticData.Configuration;
using LarQ.Core.Entities;
using LarQ.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LarQ.Startup;

public static class ServiceRegistrar
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add services to the container.
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString,
                opt => opt.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddDatabaseDeveloperPageExceptionFilter();

        // services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        //     .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI().AddDefaultTokenProviders();

        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddControllersWithViews();

        services.DependencyInjectionsInitializer();

        services.RegisterStaticDataServices(configuration);

        services.ConfigureBindingOptions(configuration);

        return services;
    }
}