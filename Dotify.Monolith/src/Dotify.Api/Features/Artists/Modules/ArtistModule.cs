using Carter;
using Carter.Response;

namespace Dotify.Api.Features.Artists.Modules;

public class ArtistModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/artists/{id}", (string id, HttpResponse res) =>
        {
            return res.Negotiate("Hi!");
        });
    }
}
