
using Dotify.Core.Artists.Queries;

namespace Dotify.Api.Features.Artists.Modules;

public class ArtistModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/artists", async (IGetArtistsQuery getArtistsQuery, HttpResponse res) =>
        {
            var artists = await getArtistsQuery.ExecuteAsync();

            return artists;
        }).IncludeInOpenApi();
    }
}
