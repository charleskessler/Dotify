
using Dotify.Api.Features.Artists.Commands;
using Dotify.Api.Features.Artists.Data;
using Dotify.Api.Models;
using Dotify.Core.Artists.Commands;
using Dotify.Core.Artists.Queries;

using Microsoft.AspNetCore.Mvc;

namespace Dotify.Api.Features.Artists.Modules;

public class ArtistModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/artists", async (IGetArtistsQuery<ArtistDto> getArtistsQuery, HttpResponse res) =>
        {
            var artists = await getArtistsQuery.ExecuteAsync();

            return artists;
        })
        .IncludeInOpenApi();

        app.MapGet("/artists/{id}", async (string id, IGetArtistByIdQuery<ArtistDto> getArtistsQuery, HttpResponse res) =>
        {
            var artist = await getArtistsQuery.ExecuteAsync(id);
            if (artist == null)
            {
                res.StatusCode = 404;
                return;
            }

            await res.Negotiate(artist);
        })
        .IncludeInOpenApi();

        app.MapPost("/artists", async (CreateArtist createArtist, ICreateArtistCommand<ArtistDto> createArtistCommand, HttpResponse res) =>
        {
            var artist = createArtistCommand.ExecuteAsync(createArtist.Name, createArtist.Genres ?? new List<string>());

            await res.Negotiate(new { Artists = artist });
        })
        .IncludeInOpenApi();
    }
}
