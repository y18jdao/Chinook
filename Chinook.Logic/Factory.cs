using System.Collections.Generic;

namespace Chinook.Logic
{
	public class Factory
	{
		public static IEnumerable<Contracts.Persistence.IAlbum> GetAllAlbums()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Album>();
		}

		public static IEnumerable<Contracts.Persistence.IArtist> GetAllArtists()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Artist>();
		}

		public static IEnumerable<Contracts.Persistence.ICustomer> GetAllCustomers()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Customer>();
		}

		public static IEnumerable<Contracts.Persistence.IEmployee> GetAllEmployees()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Employee>();
		}

		public static IEnumerable<Contracts.Persistence.IGenre> GetAllGenres()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Genre>();
		}

		public static IEnumerable<Contracts.Persistence.IInvoice> GetAllInvoices()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Invoice>();
		}

		public static IEnumerable<Contracts.Persistence.IInvoiceLine> GetAllInvoiceLines()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.InvoiceLine>();
		}

		public static IEnumerable<Contracts.Persistence.IMediaType> GetAllMediaTypes()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.MediaType>();
		}

		public static IEnumerable<Contracts.Persistence.IPlaylist> GetAllPlaylists()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Playlist>();
		}

		public static IEnumerable<Contracts.Persistence.IPlaylistTrack> GetAllPlaylistTracks()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.PlaylistTrack>();
		}

		public static IEnumerable<Contracts.Persistence.ITrack> GetAllTracks()
		{
			return CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Track>();
		}
	}
}
