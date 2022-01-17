using Dotify.Core.Artists.Entities;
using Dotify.Core.Shared;

namespace Dotify.Api.Features.Artists.Data;

public class ArtistDto : IArtist, ILocatableEntity
{
    public string Id { get; set; }
    public List<string> Genres { get; set; }
    public string Name { get; set; }
    public string Href { get; }
    public string Uri { get; }
    public string Type { get; }

    public ArtistDto(Artist a)
    {
        Id = a.Id;
        Name = a.Name;
        Genres = a.Genres;
        Type = a.GetType().Name.ToLower();
        Href = $"https://localhost:7122/artists/{a.Id}";
        Uri = $"dotify:artists:{a.Id}";
    }
}
