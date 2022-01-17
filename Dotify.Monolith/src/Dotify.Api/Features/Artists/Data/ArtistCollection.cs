using Dotify.Core.Artists.Entities;

using MongoDB.Driver;

namespace Dotify.Api.Features.Artists.Data;

public class ArtistCollection
{
    public IMongoCollection<Artist> Artists { get; }
    public ArtistCollection(IMongoDatabase database)
    {
        Artists = database.GetCollection<Artist>("artists");
    }
}
