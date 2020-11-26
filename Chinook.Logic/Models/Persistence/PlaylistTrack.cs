using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models.Persistence
{
    [DataClass(HasHeader = true, FileName = "CsvData/PlaylistTrack.csv")]
    internal class PlaylistTrack : Contracts.Persistence.IPlaylistTrack
    {
        [DataPropertyInfo(OrderPosition = 1)]
        public int PlaylistId { get; set; }

        [DataPropertyInfo(OrderPosition = 2)]
        public int TrackId { get; set; }
    }
}
