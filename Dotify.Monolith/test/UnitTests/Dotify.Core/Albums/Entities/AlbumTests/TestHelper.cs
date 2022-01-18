
using Dotify.Core.Albums.Entities;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public static class TestHelper
{
    private static readonly string _albumId = "ALBUM ID";
    private static readonly string _albumTitle = "ALBUM TITLE!";
    private static readonly string _releaseDate = "2022-02-22";
    public static Album CreateAlbum()
    {
        return new Album(_albumId, _albumTitle, _releaseDate);
    }
}
