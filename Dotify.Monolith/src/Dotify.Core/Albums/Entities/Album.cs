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
    public IReadOnlyCollection<AlbumTrack> Tracks => _tracks.AsReadOnly();
    public string ArtistId { get; private set; }
    public Album(string artistId)
    {
        ArtistId = artistId;
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

}
