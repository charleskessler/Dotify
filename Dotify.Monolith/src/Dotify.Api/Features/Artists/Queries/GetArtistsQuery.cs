using Dotify.Api.Features.Artists.Data;
using Dotify.Core.Artists.Entities;
using Dotify.Core.Artists.Queries;

using MongoDB.Driver;

namespace Dotify.Api.Features.Artists.Queries;

public class GetArtistsQuery : IGetArtistsQuery
{
    private readonly ArtistCollection _collection;

    public GetArtistsQuery(ArtistCollection collection)
    {
        _collection = collection;
    }

    public async Task<IEnumerable<Artist>> ExecuteAsync()
    {
        var filter = Builders<Artist>.Filter.Empty;
        var results = await _collection.Artists.FindAsync(filter);

        return await results.ToListAsync();
    }
}
