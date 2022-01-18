using Dotify.Api.Features.Albums.Commands;
using Dotify.Api.Features.Albums.Queries;
using Dotify.Core.Albums.Commands;
using Dotify.Core.Albums.Queries;

namespace Dotify.Api.Features.Albums.Data;

public static class AlbumsServicesRegistration
{
    public static IServiceCollection AddAlbums(this IServiceCollection services)
    {
        return services.RegisterCollections()
                       .RegisterCommands()
                       .RegisterQueries();
    }
    private static IServiceCollection RegisterQueries(this IServiceCollection services)
    {
        services.AddSingleton<IGetAlbumById, GetAlbumById>();

        return services;
    }

    private static IServiceCollection RegisterCommands(this IServiceCollection services)
    {
        services.AddSingleton<ICreateAlbum, CreateAlbum>();
        return services;
    }

    private static IServiceCollection RegisterCollections(this IServiceCollection services)
    {
        services.AddSingleton<AlbumCollection>();

        return services;
    }
}
