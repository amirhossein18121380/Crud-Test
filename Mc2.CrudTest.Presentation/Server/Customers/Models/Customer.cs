using Mc2.CrudTest.Presentation.Shared.Core.Event;
using Mc2.CrudTest.Presentation.Shared.Core.Model;

namespace Mc2.CrudTest.Presentation.Server.Customers.Models;


public record Customer : Aggregate<ulong>
{

    public string? FirstName { get; private set; }
    public string? Lastname { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Email { get; private set; }
    public string? BankAccountNumber { get; private set; }

    public static Customer Create(ulong id, string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber, bool isDeleted = false)
    {
        var customer = new Customer
        {
            Id = id,
            FirstName = firstName,
            Lastname = lastName,
            DateOfBirth = dateOfBirth,
            PhoneNumber = phoneNumber,
            Email = email,
            BankAccountNumber = bankAccountNumber,
            IsDeleted = isDeleted
        };

        var @event = new CustomerCreatedDomainEvent(customer.Id, GetFullName(customer.FirstName, customer.Lastname), customer.PhoneNumber,
            customer.Email, customer.IsDeleted);

        customer.AddDomainEvent(@event);

        return customer;
    }

    public static Customer Update(ulong id, string? firstName, string? lastName, DateTime dateOfBirth, string? phoneNumber, string? email, string? bankAccountNumber, bool isDeleted = false)
    {
        var customer = new Customer
        {
            Id = id,
            FirstName = firstName,
            Lastname = lastName,
            DateOfBirth = dateOfBirth,
            PhoneNumber = phoneNumber,
            Email = email,
            BankAccountNumber = bankAccountNumber,
            IsDeleted = isDeleted
        };

        var @event = new CustomerUpdatedDomainEvent(customer.Id, GetFullName(customer.FirstName, customer.Lastname), customer.PhoneNumber,
            customer.Email, customer.IsDeleted);

        customer.AddDomainEvent(@event);

        return customer;
    }


    public static string GetFullName(string firstName, string lastName) =>
        string.Concat(firstName, lastName);
}

public record CustomerCreatedDomainEvent
    (ulong Id, string FullName, string PhoneNumber, string Email, bool IsDeleted) : IDomainEvent;

public record CustomerUpdatedDomainEvent
    (ulong Id, string FullName, string PhoneNumber, string Email, bool IsDeleted) : IDomainEvent;