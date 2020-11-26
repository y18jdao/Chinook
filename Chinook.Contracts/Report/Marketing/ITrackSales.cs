namespace Chinook.Contracts.Report.Marketing
{
	public interface ITrackSales
	{
		double Average { get; }

		IItemSecondary<int> HighestSales { get; }

		IItemSecondary<int> LowestSales { get; }

		IItemSecondary<decimal> HighestRevenue { get; }

		IItemSecondary<decimal> LowestRevenue { get; }
	}
}
