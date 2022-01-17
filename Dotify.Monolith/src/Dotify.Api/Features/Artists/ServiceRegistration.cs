using Dotify.Api.Features.Artists.Commands;
using Dotify.Api.Features.Artists.Data;
using Dotify.Api.Features.Artists.Queries;
using Dotify.Core.Artists.Commands;
using Dotify.Core.Artists.Queries;

namespace Dotify.Api.Features.Artists;

public static class ServiceRegistration
{
    public static IServiceCollection AddArtists(this IServiceCollection services)
    {
        services.RegisterCommands()
                .RegisterQueries()
                .RegisterCollections();
        
        return services;
    }

    private static IServiceCollection RegisterQueries(this IServiceCollection services)
    {
        services.AddSingleton<IGetArtistsQuery<ArtistDto>, GetArtistsQuery>();
        services.AddSingleton<IGetArtistByIdQuery<ArtistDto>, GetArtistByIdQuery>();

        return services;
    }

    private static IServiceCollection RegisterCommands(this IServiceCollection services)
    {
        services.AddSingleton<ICreateArtistCommand<ArtistDto>, CreateArtistCommand>();

        return services;
    }

    private static IServiceCollection RegisterCollections(this IServiceCollection services)
    {
        services.AddSingleton<ArtistCollection>();

        return services;
    }
}
