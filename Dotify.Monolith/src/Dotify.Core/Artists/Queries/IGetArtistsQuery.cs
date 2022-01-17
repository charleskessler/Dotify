
using Dotify.Core.Artists.Entities;

namespace Dotify.Core.Artists.Queries;

public interface IGetArtistsQuery<T> where T : IArtist
{
    Task<IEnumerable<T>> ExecuteAsync();
}
