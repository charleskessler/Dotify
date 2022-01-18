
using Dotify.Core.Shared;

namespace Dotify.Core.Albums.Entities;

public class AlbumArtist : BaseEntity<string>
{
    public int ArtistId { get; set; }
    public string Name { get; set; }

    public AlbumArtist(int artistId, string name)
    {
        ArtistId = artistId;
        Name = name;
    }
}
