namespace Dotify.Core.Artists.Entities;

public interface IArtist
{
    string Id { get; set; }
    string Name { get; set; }
    List<string> Genres { get; set; }
}