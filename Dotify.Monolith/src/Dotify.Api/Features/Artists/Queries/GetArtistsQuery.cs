using Dotify.Api.Features.Artists.Data;
using Dotify.Core.Artists.Entities;
using Dotify.Core.Artists.Queries;

using MongoDB.Driver;

namespace Dotify.Api.Features.Artists.Queries;

public class GetArtistsQuery : IGetArtistsQuery<ArtistDto>
{
    private readonly ArtistCollection _collection;

    public GetArtistsQuery(ArtistCollection collection)
    {
        _collection = collection;
    }

    public async Task<IEnumerable<ArtistDto>> ExecuteAsync()
    {
        var filter = Builders<Artist>.Filter.Empty;
        var results = await _collection.Artists.FindAsync(filter);
        var artists = await results.ToListAsync();

        var artistDtos = new List<ArtistDto>(artists.Count);

        artists.ForEach(a => artistDtos.Add(new ArtistDto(a)));

        return artistDtos;
    }
}