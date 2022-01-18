using Dotify.Api.Data.Albums;
using Dotify.Core.Albums.Entities;
using Dotify.Core.Albums.Queries;

using MongoDB.Driver;

namespace Dotify.Api.Features.Albums;

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

        return null;
    }
}
