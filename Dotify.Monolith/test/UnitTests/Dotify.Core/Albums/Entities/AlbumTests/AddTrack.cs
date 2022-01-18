namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public class AddTrack
{
    private readonly string _trackId = "TRACK ID";

    [Fact]
    public void AddsTrackIfNotExisting()
    {
        var album = TestHelper.CreateAlbum();

        album.AddTrack(_trackId);

        Assert.Single(album.Tracks);
    }

    [Fact]
    public void DoesNotAddDuplicateTrack()
    {
        var album = TestHelper.CreateAlbum();
        album.AddTrack(_trackId);

        album.AddTrack(_trackId);

        Assert.Single(album.Tracks);
    }
}
