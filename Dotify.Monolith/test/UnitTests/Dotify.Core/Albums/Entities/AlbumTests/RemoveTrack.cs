using Dotify.Core.Albums.Entities;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class RemoveTrack
{
    private readonly string _artistId = "ARTIST ID";
    private readonly string _trackId = "TRACK ID";
    private readonly int _trackNumber = 10;

    [Fact]
    public void RemovesTrackWhenExists()
    {
        var album = new Album(_artistId);
        album.AddTrack(_trackId, _trackNumber);

        album.RemoveTrack(_trackId);
        Assert.Empty(album.Tracks);  
    }

    [Fact]
    public void RemainsUnmodifiedWhenTrackNotExists()
    {
        var album = new Album(_artistId);
        album.AddTrack(_trackId, _trackNumber);

        album.RemoveTrack("not the right ID");
        Assert.Single(album.Tracks);
    }
}
