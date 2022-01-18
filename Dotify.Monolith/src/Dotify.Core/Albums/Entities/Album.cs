using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
        }

        Title = title;
        ReleaseDate = releaseDate;
    }

    public void AddTrack(string trackId, int trackNumber)
    {
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
