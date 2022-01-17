using Dotify.Api.Features.Artists.Data;
using Dotify.Core.Artists.Entities;
using Dotify.Core.Artists.Queries;

using MongoDB.Driver;

namespace Dotify.Api.Features.Artists.Queries;

public class GetArtistByIdQuery : IGetArtistByIdQuery<ArtistDto>
{
    private readonly ArtistCollection _collection;

    public GetArtistByIdQuery(ArtistCollection collection) => _collection = collection;
    public async Task<ArtistDto?> ExecuteAsync(string id)
    {
        var filter = Builders<Artist>.Filter.Where(x => x.Id == id);
        var result = await _collection.Artists.FindAsync(filter);
        
        var artist = await result.FirstOrDefaultAsync();
        return artist == null ? null : new ArtistDto(artist);
    }
}
