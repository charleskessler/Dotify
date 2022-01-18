using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class RemoveArtist
{
    public readonly string _artistId = "ARTIST ID";
    public readonly string _artistName = "ARTIST NAME";
    [Fact]
    public void RemoveAlbumArtistIfPresent()
    {
        var album = TestHelper.CreateAlbum();

        album.AddArtist(_artistId, _artistName);
        album.RemoveArtist(_artistId);

        Assert.Empty(album.Artists);
    }

    [Fact]
    public void RemainsUnmodifiedWhenArtistNotExists()
    {
        var album = TestHelper.CreateAlbum();

        album.AddArtist(_artistId, _artistName);
        album.RemoveArtist("not a real ID!");

        Assert.Single(album.Artists);
    }
}
