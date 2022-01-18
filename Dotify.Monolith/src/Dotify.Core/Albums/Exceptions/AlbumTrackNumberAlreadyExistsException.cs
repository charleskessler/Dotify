namespace Dotify.Core.Albums.Exceptions;

public class AlbumTrackNumberAlreadyExistsException : Exception
{
    public AlbumTrackNumberAlreadyExistsException(string trackId, int trackNumber) : base($"Track {trackId} could not be added to Album: a track with track number {trackNumber} already exists.")
    {
    }
}
