using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models.Persistence
{
    [DataClass(HasHeader = true, FileName = "CsvData/InvoiceLine.csv")]
    internal class InvoiceLine : IdentityObject, Contracts.Persistence.IInvoiceLine
    {
        [DataPropertyInfo(OrderPosition = 1)]
        public int InvoiceId { get; set; }

        [DataPropertyInfo(OrderPosition = 2)]
        public int TrackId { get; set; }

        [DataPropertyInfo(OrderPosition = 3)]
        public decimal UnitPrice { get; set; }

        [DataPropertyInfo(OrderPosition = 4)]
        public int Quantity { get; set; }
    }
}
