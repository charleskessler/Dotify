using System;

using Dotify.Core.Albums.Entities;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class RemoveTrack
{
    private readonly string _albumTitle = "ALBUM TITLE!";
    private readonly DateOnly _releaseDate = new(2022, 2, 22);
    private readonly string _trackId = "TRACK ID";
    private readonly int _trackNumber = 10;

    [Fact]
    public void RemovesTrackWhenExists()
    {
        var album = new Album(_albumTitle, _releaseDate);
        album.AddTrack(_trackId, _trackNumber);

        album.RemoveTrack(_trackId);
        Assert.Empty(album.Tracks);  
    }

    [Fact]
    public void RemainsUnmodifiedWhenTrackNotExists()
    {
        var album = new Album(_albumTitle, _releaseDate);
        album.AddTrack(_trackId, _trackNumber);

        album.RemoveTrack("not the right ID");
        Assert.Single(album.Tracks);
    }
}
