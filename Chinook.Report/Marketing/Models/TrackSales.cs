using Chinook.Contracts.Report.Marketing;

namespace Chinook.Report.Marketing.Models
{
    internal class TrackSales : ITrackSales
    {
        public double Average { get; set; }

        public IItemSecondary<int> HighestSales { get; set; }

        public IItemSecondary<int> LowestSales { get; set; }

        public IItemSecondary<decimal> HighestRevenue { get; set; }

        public IItemSecondary<decimal> LowestRevenue { get; set; }
    }
}
