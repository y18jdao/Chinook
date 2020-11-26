namespace Chinook.Contracts.Persistence
{
    public interface IInvoiceLine : IIdentifiable
    {
        int InvoiceId { get; set; }

        int TrackId { get; set; }

        decimal UnitPrice { get; set; }

        int Quantity { get; set; }
    }
}
