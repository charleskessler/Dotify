
using Ardalis.GuardClauses;

using Dotify.Core.Albums.Exceptions;
using Dotify.Core.Shared;

namespace Dotify.Core.Albums.Entities;

public class Album : BaseEntity<string>, IAggregateRoot
{
    private readonly List<AlbumTrack> _tracks = new();
    private readonly List<AlbumArtist> _artists = new();
    public IReadOnlyCollection<AlbumTrack> Tracks => _tracks.AsReadOnly();
    public IReadOnlyCollection<AlbumArtist> Artists => _artists.AsReadOnly();
    public string Title { get; private set; }
    public DateOnly ReleaseDate { get; private set; }

    public Album(string title, DateOnly releaseDate)
    {
        Guard.Against.NullOrWhiteSpace(title, nameof(title));

        Title = title;
        ReleaseDate = releaseDate;
    }

    public void AddArtist(string artistId, string name)
    {
        Guard.Against.NullOrWhiteSpace(artistId, nameof(artistId));
        Guard.Against.NullOrWhiteSpace(name, nameof(name));

        if (_artists.Any(a => a.ArtistId == artistId))
        {
            return;
        }

        _artists.Add(new AlbumArtist(artistId, name));
    }

    public void RemoveArtist(string artistId)
    {
        _artists.RemoveAll(a => a.ArtistId == artistId);
    }

    public void AddTrack(string trackId, int trackNumber)
    {
        Guard.Against.NullOrWhiteSpace(trackId, nameof(trackId));
        Guard.Against.OutOfRange(trackNumber, nameof(trackNumber), 1, int.MaxValue);

        if (_tracks.Any(t => t.Number == trackNumber))
        {
            throw new AlbumTrackNumberAlreadyExistsException(trackId, trackNumber);
        }

        if (_tracks.Any(t => t.TrackId == trackId))
        {
            return;
        }

        _tracks.Add(new AlbumTrack(trackId, trackNumber));
    }

    public void RemoveTrack(string trackId)
    {
        _tracks.RemoveAll(t => t.TrackId == trackId);
    }
}
