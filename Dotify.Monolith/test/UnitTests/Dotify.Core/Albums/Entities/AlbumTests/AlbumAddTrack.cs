using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dotify.Core.Albums.Entities;
using Dotify.Core.Albums.Exceptions;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class AlbumAddTrack
{
    private readonly string _artistId = "ARTIST ID";
    private readonly string _trackId = "TRACK ID";
    private readonly int _trackNumber = 10;

    [Fact]
    public void AddsAlbumTrackIfNotExisting()
    {
        var album = new Album(_artistId);
        album.AddTrack(_trackId, _trackNumber);

        var albumTrack = album.Tracks.Single();
        Assert.Equal(_trackId, albumTrack.TrackId);
        Assert.Equal(_trackNumber, albumTrack.Number);
    }

    [Fact]
    public void CantAddTrackAtExistingNumber()
    {
        var album = new Album(_artistId);
        album.AddTrack(_trackId, _trackNumber);

        Assert.Throws<AlbumTrackNumberAlreadyExistsException>(() => album.AddTrack(_trackId, _trackNumber));
    }

    [Fact]
    public void KeepsExistingTrackWhenAddingDuplicate()
    {
        var album = new Album(_artistId);
        album.AddTrack(_trackId, _trackNumber);

        album.AddTrack(_trackId, 4);

        var albumTrack = album.Tracks.Single();
        Assert.Equal(_trackId, albumTrack.TrackId);
        Assert.Equal(_trackNumber, albumTrack.Number);
    }
}
