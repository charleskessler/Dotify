using Dotify.Api.Features.Albums.Data;
using Dotify.Api.Features.Artists;

namespace Dotify.Api.Startup;

public static class FeatureServiceRegistration
{
    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        services.AddArtists();
        services.AddAlbums();

        return services;
    }
}
