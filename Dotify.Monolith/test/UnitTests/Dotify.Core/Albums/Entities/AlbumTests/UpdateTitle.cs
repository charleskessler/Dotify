using System;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class UpdateTitle
{
    [Fact]
    public void ShouldUpdateTitle()
    {
        var album = TestHelper.CreateAlbum();

        album.UpdateTitle("NEW ALBUM TITLE");

        Assert.Equal("NEW ALBUM TITLE", album.Title);
    }

    [Fact]
    public void ShouldNotChangeToInvalidTitle()
    {
        var album = TestHelper.CreateAlbum();

        Assert.Throws<ArgumentException>(() => album.UpdateTitle(""));
        Assert.Throws<ArgumentException>(() => album.UpdateTitle("                    "));
    }
}
