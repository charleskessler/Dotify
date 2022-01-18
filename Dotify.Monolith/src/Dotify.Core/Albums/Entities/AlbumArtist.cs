
using Dotify.Core.Shared;

namespace Dotify.Core.Albums.Entities;

public class AlbumArtist : BaseEntity<string>
{
    public string ArtistId { get; set; }
    public string Name { get; set; }

    public AlbumArtist(string artistId, string name)
    {
        ArtistId = artistId;
        Name = name;
    }
}
