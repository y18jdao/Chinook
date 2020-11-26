using Chinook.Contracts.Report.Marketing;

namespace Chinook.Report.Marketing.Models
{
    internal class CustomersInfo : ICustomersInfo
    {
        public double Average { get; set; }

        public IItemSecondary<decimal> TopCustomer { get; set; }

        public IItemSecondary<decimal> BottomCustomer { get; set; }
    }
}
