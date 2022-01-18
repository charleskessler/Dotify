using Dotify.Api.Features.Albums.Data;
using Dotify.Core.Albums.Commands;
using Dotify.Core.Albums.Entities;

using MongoDB.Bson;

namespace Dotify.Api.Features.Albums.Commands;

public class CreateAlbum : ICreateAlbum
{
    private readonly AlbumCollection _collection;

    public CreateAlbum(AlbumCollection collection)
    {
        _collection = collection;
    }
    public async Task<Album> Execute(string title, string releaseDate)
    {
        var id = ObjectId.GenerateNewId().ToString();
        var album = new Album(id, title, releaseDate);

        await _collection.Albums.InsertOneAsync(album);

        return album;
    }
}
