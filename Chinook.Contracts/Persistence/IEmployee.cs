using System;

namespace Chinook.Contracts.Persistence
{
    public interface IEmployee : IIdentifiable
    {
        string LastName { get; set; }

        string FirstName { get; set; }

        string Title { get; set; }

        int ReportsTo { get; set; }

        DateTime BirthDate { get; set; }

        DateTime HireDate { get; set; }

        string Address { get; set; }

        string City { get; set; }

        string State { get; set; }

        string Country { get; set; }

        string PostalCode { get; set; }

        string Phone { get; set; }

        string Fax { get; set; }

        string Email { get; set; }
    }
}
