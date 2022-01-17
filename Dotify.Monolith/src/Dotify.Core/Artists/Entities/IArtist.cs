
using Dotify.Core.Shared;

namespace Dotify.Core.Artists.Entities;

public interface IArtist : IEntity
{
    string Name { get; set; }
    List<string> Genres { get; set; }
}