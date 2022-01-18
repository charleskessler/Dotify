using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dotify.Core.Albums.Entities;

namespace UnitTests.Dotify.Core.Albums.Entities.AlbumTests;

public static class TestHelper
{
    public static Album CreateAlbum()
    {
        return new Album("ALBUM TITLE!", new DateOnly(2001, 09, 11));
    }
}
