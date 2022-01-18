
using Dotify.Core.Shared;

namespace Dotify.Core.Albums.Entities;

public class AlbumArtist : BaseEntity<string>
{
    public string ArtistId { get; private set; }
    public string Name { get; private set; }

    public AlbumArtist(string artistId, string name)
    {
        ArtistId = artistId;
        Name = name;
    }
}
