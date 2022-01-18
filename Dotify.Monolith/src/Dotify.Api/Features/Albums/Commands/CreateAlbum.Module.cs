using Dotify.Core.Albums.Commands;

namespace Dotify.Api.Features.Albums.Commands;

public class CreateAlbumModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/albums", async (CreateAlbumRequest request, ICreateAlbum command, HttpResponse res) =>
        {
            var album = await command.Execute(request.Title, request.ReleaseDate.ToString());

            await res.Negotiate(album);

        }).IncludeInOpenApi();
    }
}
