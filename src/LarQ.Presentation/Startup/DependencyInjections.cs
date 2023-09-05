using LarQ.Core.Common;
using LarQ.Core.Contracts;
using LarQ.Core.Entities;
using LarQ.DataAccess.Contracts;
using LarQ.DataAccess.Repositories;
using LarQ.Services;
using LarQ.Services.Base;
using LarQ.Services.Contracts;

namespace LarQ.Startup;

public static class DependencyInjections
{
    public static IServiceCollection DependencyInjectionsInitializer(this IServiceCollection services)
    {
        // Scoped  


        // Transits 

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        // services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddTransient<IPodcastService, PodcastService>();


        // singleton 


        return services;
    }
}