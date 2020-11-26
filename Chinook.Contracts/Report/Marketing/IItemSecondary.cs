namespace Chinook.Contracts.Report.Marketing
{
	public interface IItemSecondary<T>
	{
		string Name { get; }

		T Secondary { get; }
	}
}
