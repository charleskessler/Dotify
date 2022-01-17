namespace Dotify.Core.Entities;

public class Artist
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<string> Genres { get; set; } = new();

    public Artist(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
