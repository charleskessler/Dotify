namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class RemoveArtist
{
    public readonly string _artistId = "ARTIST ID";

    [Fact]
    public void RemoveAlbumArtistIfPresent()
    {
        var album = TestHelper.CreateAlbum();

        album.AddArtist(_artistId);
        album.RemoveArtist(_artistId);

        Assert.Empty(album.Artists);
    }

    [Fact]
    public void RemainsUnmodifiedWhenArtistNotExists()
    {
        var album = TestHelper.CreateAlbum();

        album.AddArtist(_artistId);
        album.RemoveArtist("not a real ID!");

        Assert.Single(album.Artists);
    }
}
