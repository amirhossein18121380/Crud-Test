using Mc2.CrudTest.Presentation.Server.Customers.Models;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;

public record UpdateCustomerRequestDto(ulong Id, string FirstName, string LastName, DateTime DateOfBirth,
    string PhoneNumber, string Email, string BankAccountNumber);

public record UpdateCustomerResult(Customer Customer);

public record UpdateCustomerResponseDto(UpdateCustomerResult Result);