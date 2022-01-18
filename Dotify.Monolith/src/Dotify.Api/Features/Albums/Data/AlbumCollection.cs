using Dotify.Core.Albums.Entities;

using MongoDB.Driver;

namespace Dotify.Api.Features.Albums.Data;

public class AlbumCollection
{
    public IMongoCollection<Album> Albums { get; }
    public AlbumCollection(IMongoDatabase database)
        => Albums = database.GetCollection<Album>("albums");
}
