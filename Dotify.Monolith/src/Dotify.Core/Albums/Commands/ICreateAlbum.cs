
using Dotify.Core.Albums.Entities;

namespace Dotify.Core.Albums.Commands;

public interface ICreateAlbum
{
    Task<Album> Execute(string title, string releaseDate);
}
