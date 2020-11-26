using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models.Persistence
{
    [DataClass(HasHeader = true, FileName = "CsvData/Playlist.csv")]
    internal class Playlist : IdentityObject, Contracts.Persistence.IPlaylist
    {
        [DataPropertyInfo(OrderPosition = 1)]
        public string Name { get; set; }
    }
}
