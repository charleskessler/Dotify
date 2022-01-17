using Dotify.Api.Features.Artists.Data;
using Dotify.Api.Features.Artists.Queries;
using Dotify.Core.Artists.Queries;

namespace Dotify.Api.Features.Artists;

public static class ServiceRegistration
{
    public static IServiceCollection AddArtists(this IServiceCollection services)
    {
        RegisterCollections(services);
        RegisterQueries(services);

        return services;
    }

    private static IServiceCollection RegisterQueries(IServiceCollection services)
    {
        services.AddSingleton<IGetArtistsQuery<ArtistDto>, GetArtistsQuery>();

        return services;
    }

    private static IServiceCollection RegisterCollections(IServiceCollection services)
    {
        services.AddSingleton<ArtistCollection>();

        return services;
    }
}
