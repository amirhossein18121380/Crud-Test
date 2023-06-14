namespace Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;

public record AddCustomerRequestDto(string FirstName, string LastName, DateTime DateOfBirth,
        string PhoneNumber, string Email, string BankAccountNumber);

public record AddCustomerResult(Guid Id);

public record AddCustomerResponseDto(Guid Id);