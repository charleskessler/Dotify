using System;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class RemoveTrack
{
    private readonly string _trackId = "TRACK ID";

    [Fact]
    public void RemovesTrackWhenExists()
    {
        var album = TestHelper.CreateAlbum();
        album.AddTrack(_trackId);

        album.RemoveTrack(_trackId);

        Assert.Empty(album.Tracks);
    }

    [Fact]
    public void RemainsUnmodifiedWhenTrackNotExists()
    {
        var album = TestHelper.CreateAlbum();
        album.AddTrack(_trackId);

        album.RemoveTrack("not the right ID");

        Assert.Single(album.Tracks);
    }
}
