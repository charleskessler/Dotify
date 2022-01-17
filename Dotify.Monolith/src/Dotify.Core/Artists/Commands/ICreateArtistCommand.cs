
using Dotify.Core.Artists.Entities;

namespace Dotify.Core.Artists.Commands;

public interface ICreateArtistCommand<T> where T : IArtist
{
    Task<T> ExecuteAsync(string name, List<string> genres);
}
