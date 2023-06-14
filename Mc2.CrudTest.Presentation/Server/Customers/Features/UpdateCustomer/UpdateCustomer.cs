using Mc2.CrudTest.Presentation.Shared.Core.CQRS;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;

public record UpdateCustomer(ulong Id, string FirstName, string Lastname, DateTime DateOfBirth,
    string PhoneNumber, string Email, string BankAccountNumber) : ICommand<UpdateCustomerResult>
{ }