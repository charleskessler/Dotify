
namespace Dotify.Core.Artists.Entities;

public interface IArtist
{
    List<string> Genres { get; set; }
    string Id { get; set; }
    string Name { get; set; }
}