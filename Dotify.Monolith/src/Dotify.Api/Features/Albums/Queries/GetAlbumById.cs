using Dotify.Api.Features.Albums.Data;
using Dotify.Core.Albums.Entities;
using Dotify.Core.Albums.Queries;

using MongoDB.Driver;

namespace Dotify.Api.Features.Albums.Queries;

public class GetAlbumById : IGetAlbumById
{
    private readonly AlbumCollection _collection;

    public GetAlbumById(AlbumCollection collection)
    {
        _collection = collection;
    }

    public async Task<Album?> Execute(string id)
    {
        var filter = Builders<Album>.Filter.Where(a => a.Id == id);
        var result = await _collection.Albums.FindAsync(filter);

        return await result.SingleOrDefaultAsync();
    }
}
