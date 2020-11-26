using System;

namespace Chinook.Contracts.Persistence
{
    public interface IInvoice : IIdentifiable
    {
         int CustomerId { get; set; }

         DateTime InvoiceDate { get; set; }

         string BillingAddress { get; set; }

         string BillingCity { get; set; }

         string BillingState { get; set; }

         string BillingCountry { get; set; }

         string BillingPostalCode { get; set; }

         Decimal Total { get; set; }
    }
}
