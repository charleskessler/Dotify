using Dotify.Core.Albums.Queries;

namespace Dotify.Api.Features.Albums;

public class GetAlbumByIdModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/albums/{id}", async (string id, IGetAlbumById query, HttpResponse res) =>
        {
            var album = await query.Execute(id);

            if (album is null)
            {
                res.StatusCode = 404;
                return;
            }

            await res.Negotiate(album);
        })
        .IncludeInOpenApi();
    }
}
