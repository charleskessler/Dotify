using System;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class UpdateReleaseDate
{

    [Fact]
    public void ShouldUpdateReleaseDate()
    {
        var album = TestHelper.CreateAlbum();

        album.UpdateReleaseDate("2022-02-22");

        Assert.Equal("2022-02-22", album.ReleaseDate);
    }

    [Fact]
    public void CantChangeToInvalidDate()
    {
        var album = TestHelper.CreateAlbum();

        Assert.Throws<ArgumentException>(() => album.UpdateReleaseDate("NOT A DATE"));
    }
}
