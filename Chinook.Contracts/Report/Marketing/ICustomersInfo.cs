namespace Chinook.Contracts.Report.Marketing
{
	public interface ICustomersInfo
	{
		double Average { get; }

		IItemSecondary<decimal> TopCustomer { get; }

		IItemSecondary<decimal> BottomCustomer { get; }
	}
}
