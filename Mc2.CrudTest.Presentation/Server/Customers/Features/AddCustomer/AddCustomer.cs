using Mc2.CrudTest.Presentation.Shared.Core.CQRS;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;

public record AddCustomer(string FirstName, string Lastname, DateTime DateOfBirth,
    string PhoneNumber, string Email, string BankAccountNumber) : ICommand<AddCustomerResult>
{
    public Guid Id { get; init; } = Guid.NewGuid();
}