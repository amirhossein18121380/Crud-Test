using Mc2.CrudTest.Presentation.Shared.Core.Pagination;

namespace Mc2.CrudTest.Presentation.Client.Dtos.Customer;


public record UpdateDto(ulong Id, string FirstName, string LastName, DateTime DateOfBirth,
    string PhoneNumber, string Email, string BankAccountNumber);

public record GetCustomersByPageRequestDto
    (int PageNumber, int PageSize, string? Filters, string? SortOrder) : IPageRequest;

public record GetCustomersByPageRequestDto2
    (int PageNumber, int PageSize);

public record GetCustomersByPageResponseDto(IPageList<CustomerDto> Customers);

public record CustomerDto(ulong Id, string FirstName, string LastName, DateTime DateOfBirth, string PhoneNumber, string Email, string BankAccountNumber);

public record AddCustomerRequestDto(string FirstName, string LastName, DateTime DateOfBirth,
    string PhoneNumber, string Email, string BankAccountNumber);

public record AddCustomerResult(ulong Id);

public record AddCustomerResponseDto(ulong Id);