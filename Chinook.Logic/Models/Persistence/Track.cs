using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models.Persistence
{
    [DataClass(HasHeader = true, FileName = "CsvData/Track.csv")]
    internal class Track : IdentityObject, Contracts.Persistence.ITrack
    {
        [DataPropertyInfo(OrderPosition = 1)]
        public string Name { get; set; }

        [DataPropertyInfo(OrderPosition = 2)]
        public int AlbumId { get; set; }

        [DataPropertyInfo(OrderPosition = 3)]
        public int MediaTypeId { get; set; }

        [DataPropertyInfo(OrderPosition = 4)]
        public int GenreId { get; set; }

        [DataPropertyInfo(OrderPosition = 5)]
        public string Composer { get; set; }

        [DataPropertyInfo(OrderPosition = 6)]
        public int Miliseconds { get; set; }

        [DataPropertyInfo(OrderPosition = 7)]
        public int Bytes { get; set; }

        [DataPropertyInfo(OrderPosition = 8)]
        public decimal UnitPrice { get; set; }
    }
}
