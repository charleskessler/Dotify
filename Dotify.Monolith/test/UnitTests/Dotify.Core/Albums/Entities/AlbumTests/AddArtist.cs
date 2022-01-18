using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class AddArtist
{
    public readonly string _artistId = "ARTIST ID";
    public readonly string _artistName = "ARTIST NAME";
    [Fact]
    public void AddAlbumArtistIfNotPresent()
    {
        var album = TestHelper.CreateAlbum();

        album.AddArtist(_artistId, _artistName);

        Assert.Single(album.Artists);
    }

    [Fact]
    public void DotNotAddAlbumArtistIfAlreadyPresent()
    {
        var album = TestHelper.CreateAlbum();

        album.AddArtist(_artistId, _artistName);
        album.AddArtist(_artistId, _artistName);

        Assert.Single(album.Artists);
    }
}
