
using Dotify.Core.Artists.Entities;

namespace Dotify.Core.Artists.Queries;

public interface IGetArtistByIdQuery<T> where T : IArtist
{
    Task<T?> ExecuteAsync(string id);
}
