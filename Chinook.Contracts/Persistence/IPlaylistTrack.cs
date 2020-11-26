namespace Chinook.Contracts.Persistence
{
    public interface IPlaylistTrack
    {
        int PlaylistId { get; }

        int TrackId { get; }
    }
}
