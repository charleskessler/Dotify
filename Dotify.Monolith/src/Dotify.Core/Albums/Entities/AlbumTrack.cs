
using Dotify.Core.Shared;

namespace Dotify.Core.Albums.Entities;

public class AlbumTrack : BaseEntity<string>
{
    public string TrackId { get; private set; }
    public int Number { get; private set; }

    public AlbumTrack(string trackId, int number)
    {
        TrackId = trackId;
        Number = number;
    }
}
