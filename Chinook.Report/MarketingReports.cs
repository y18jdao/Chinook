using System.Linq;
using System.Collections.Generic;
using Chinook.Contracts.Persistence;
using Chinook.Contracts.Report.Marketing;
using Chinook.Report.Marketing.Models;

namespace Chinook.Report
{
	public class MarketingReports
	{
		private static IEnumerable<ITrack> tracks = Logic.Factory.GetAllTracks();
		private static IEnumerable<IAlbum> albums = Logic.Factory.GetAllAlbums();
		private static IEnumerable<IInvoiceLine> invoiceLines = Logic.Factory.GetAllInvoiceLines();
		private static IEnumerable<IInvoice> invoices = Logic.Factory.GetAllInvoices();
		private static IEnumerable<ICustomer> customers = Logic.Factory.GetAllCustomers();
		private static IEnumerable<IGenre> genres = Logic.Factory.GetAllGenres();

		public static IEnumerable<IArtistStatistic> GetArtistStatistics()
		{
			var artists = Logic.Factory.GetAllArtists();

			// Abfrage 
			var result = default(IEnumerable<IArtistStatistic>);

			return result;
		}

		public static (double avg, ITrackTime longest, ITrackTime shortest) GetTrackTimes()
        {
			ITrack longest = tracks.Aggregate((a, b) => a.Miliseconds > b.Miliseconds ? a : b);
			double avg = tracks.Average(c => c.Miliseconds);
			ITrack shortest = tracks.Aggregate((a, b) => a.Miliseconds < b.Miliseconds ? a : b);
			return (avg, new TrackTime() { Name = longest.Name, Seconds = longest.Miliseconds / 1000 }, new TrackTime() { Name = shortest.Name, Seconds = shortest.Miliseconds / 1000 });
        }

		public static (double avg, IAlbumTime longest, IAlbumTime shortest) GetAlbumTime()
        {
			var new_tracks = (from pl in tracks
							  group pl by pl.AlbumId into trackGroup
							  select new
							  {
								  AlbumId = trackGroup.Key,
								  TotalTime = trackGroup.Sum(x => x.Miliseconds) / 1000
							  }).OrderByDescending(c => c.TotalTime);

			var t = new_tracks.First();
			var l = new_tracks.Last();
			IAlbum top = albums.ToList().Find(a => a.Id == t.AlbumId);
			IAlbum last = albums.ToList().Find(a => a.Id == l.AlbumId);
			double avg = new_tracks.Average(c => c.TotalTime);

			return (avg, new AlbumTime() { Name = top.Title, Seconds = t.TotalTime }, new AlbumTime() { Name = last.Title, Seconds = l.TotalTime});
        }

		public static ITrackSales GetTrackSales()
        {
			var invoiceQuantities = (from il in invoiceLines
									 group il by il.TrackId into ilGroup
									 select new
									 {
										 TrackId = ilGroup.Key,
										 Quantity = ilGroup.Sum(x => x.Quantity),
										 Price = ilGroup.Sum(x => x.Quantity) * ilGroup.Sum(x => x.UnitPrice)
									 });

			var firstTrack = invoiceQuantities.OrderByDescending(c => c.Quantity).First();
			var lastTrack = invoiceQuantities.OrderByDescending(c => c.Quantity).Last();
			ITrack track = tracks.ToList().Find(c => c.Id == firstTrack.TrackId);
			ITrack track2 = tracks.ToList().Find(c => c.Id == lastTrack.TrackId);

			var firstTrackPrince = invoiceQuantities.OrderByDescending(c => c.Price).First();
			var lastTrackPrince = invoiceQuantities.OrderByDescending(c => c.Price).Last();
			ITrack trackPrice = tracks.ToList().Find(c => c.Id == firstTrackPrince.TrackId);
			ITrack trackPrice2 = tracks.ToList().Find(c => c.Id == lastTrackPrince.TrackId);

			double avg = (double)invoiceQuantities.Average(c => c.Price);

			return new TrackSales()
			{
				Average = avg,
				HighestSales = new ItemSecondary<int>() { Name = track.Name, Secondary = firstTrack.Quantity },
				LowestSales = new ItemSecondary<int>() { Name = track2.Name, Secondary = lastTrack.Quantity },
				HighestRevenue = new ItemSecondary<decimal>() { Name = trackPrice.Name, Secondary = firstTrackPrince.Price },
				LowestRevenue = new ItemSecondary<decimal>() { Name = trackPrice2.Name, Secondary = lastTrackPrince.Price }
			};
		}

		public static ICustomersInfo GetCustomersInfo()
        {
			var invoiceLinesCust = (from il in invoiceLines
									group il by il.InvoiceId into ilGroup
									select new
									{
										InvoiceId = ilGroup.Key,
										Quantity = ilGroup.Sum(x => x.Quantity),
										Price = ilGroup.Sum(x => x.Quantity) * ilGroup.Sum(x => x.UnitPrice)
									}).OrderByDescending(c => c.Price);


			var topCustF = invoiceLinesCust.First();
			var bottomCustF = invoiceLinesCust.Last();
			var topInvoice = invoices.ToList().Find(c => c.Id == topCustF.InvoiceId);
			var bottomInvoice = invoices.ToList().Find(c => c.Id == bottomCustF.InvoiceId);

			ICustomer topCust = customers.ToList().Find(c => c.Id == topInvoice.CustomerId);
			ICustomer bottomCust = customers.ToList().Find(c => c.Id == bottomInvoice.CustomerId);

			double avg = (double)invoiceLinesCust.Average(c => c.Price);

			return new CustomersInfo()
			{
				Average = avg,
				TopCustomer = new ItemSecondary<decimal>() { Name = topCust.FirstName + " " + topCust.LastName, Secondary = topCustF.Price },
				BottomCustomer = new ItemSecondary<decimal>() { Name = bottomCust.FirstName + " " + bottomCust.LastName, Secondary = bottomCustF.Price}
			};
		}
	
		public static (IItemSecondary<int> a, IItemSecondary<int> b) GetGenresInfo()
        {
			var y = (from il in invoiceLines
					 join tr in tracks
						 on il.TrackId equals tr.Id
					 join gr in genres
						 on tr.GenreId equals gr.Id
					 group new { tr, il, gr } by tr.GenreId into g
					 select new
					 {
						 GenreId = g.Key,
						 Quantity = g.Sum(c => c.il.Quantity)
					 }).OrderByDescending(c => c.Quantity);

			var topGenreF = y.First();
			var bottomGenreL = y.Last();
			var topGenre = genres.ToList().Find(c => c.Id == topGenreF.GenreId);
			var bottomGenre = genres.ToList().Find(c => c.Id == bottomGenreL.GenreId);

			return (new ItemSecondary<int>() { Name = topGenre.Name, Secondary = topGenreF.Quantity },
				new ItemSecondary<int>() { Name = bottomGenre.Name, Secondary = bottomGenreL.Quantity });
		}
	}
}
