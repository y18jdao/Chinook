namespace Chinook.Contracts.Persistence
{
    public interface ITrack : IIdentifiable
    {
        string Name { get; set; }

        int AlbumId { get; set; }

        int MediaTypeId { get; set; }

        int GenreId { get; set; }

        string Composer { get; set; }

        int Miliseconds { get; set; }

        int Bytes { get; set; }

        decimal UnitPrice { get; set; }
    }
}
