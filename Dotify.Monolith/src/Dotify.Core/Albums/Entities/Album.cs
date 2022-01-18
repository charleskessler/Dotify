
using Ardalis.GuardClauses;

using Dotify.Core.Shared;

namespace Dotify.Core.Albums.Entities;

public class Album : AggregateRoot<string>
{
    public string Title { get; private set; }

    private DateOnly _releaseDate;
    public string ReleaseDate
    {
        get
        {
            return _releaseDate.ToString("yyyy-MM-dd");
        }

        private set
        {
            if (!DateOnly.TryParse(value, out _releaseDate))
            {
                throw new ArgumentException($"Release Date '{value}' is invalid.");
            }
        }
    }

    public List<string> Artists { get; private set; } = new();
    public List<string> Tracks { get; private set; } = new();

    public Album(string id, string title, string releaseDate) : base(id)
    {
        Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
        ReleaseDate = releaseDate;
    }

    public void AddArtist(string artistId)
    {
        Guard.Against.NullOrWhiteSpace(artistId, nameof(artistId));

        if (Artists.Any(id => id == artistId))
        {
            return;
        }

        Artists.Add(artistId);
    }

    public void RemoveArtist(string artistId)
        => Artists.RemoveAll(id => id == artistId);

    public void AddTrack(string trackId)
    {
        Guard.Against.NullOrWhiteSpace(trackId, nameof(trackId));

        if (Tracks.Any(id => id == trackId))
        {
            return;
        }

        Tracks.Add(trackId);
    }

    public void RemoveTrack(string trackId)
        => Tracks.RemoveAll(id => id == trackId);

    public void UpdateReleaseDate(string releaseDate)
        => ReleaseDate = releaseDate;
    public void UpdateTitle(string title)
        => Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
}
