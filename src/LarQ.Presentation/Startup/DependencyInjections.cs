using LarQ.Common;
using LarQ.Common.Contracts;
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
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddTransient<IPodcastService, PodcastService>();
        services.AddTransient<ISubscribeService, SubscribeService>();
        services.AddTransient<IReactService, ReactService>();
        services.AddTransient<IPlaylistService, PlaylistService>();
        services.AddTransient<IFavoriteService, FavoriteService>();
        services.AddTransient<ICommentService, CommentService>();


        // singleton 
        services.AddSingleton<IFileUploadExtension, FileUploadExtension>();


        return services;
    }
}