namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class AddArtist
{
    public readonly string _artistId = "ARTIST ID";
    public readonly string _artistName = "ARTIST NAME";
    [Fact]
    public void AddAlbumArtistIfNotPresent()
    {
        var album = TestHelper.CreateAlbum();

        album.AddArtist(_artistId);

        Assert.Single(album.Artists);
    }

    [Fact]
    public void DotNotAddAlbumArtistIfAlreadyPresent()
    {
        var album = TestHelper.CreateAlbum();


        album.AddArtist(_artistId);
        album.AddArtist(_artistId);

        Assert.Single(album.Artists);
    }
}
