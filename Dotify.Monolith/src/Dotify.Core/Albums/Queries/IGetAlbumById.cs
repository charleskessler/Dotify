
using Dotify.Core.Albums.Entities;

namespace Dotify.Core.Albums.Queries;

public interface IGetAlbumById
{
    Task<Album?> Execute(string id);
}
