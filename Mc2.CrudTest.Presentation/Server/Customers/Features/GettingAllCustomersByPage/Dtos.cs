using Mc2.CrudTest.Presentation.Shared.Core.Pagination;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.GettingAllCustomersByPage;

public record CustomerDto(ulong Id, string FirstName, string LastName, DateTime DateOfBirth, string PhoneNumber, string Email, string BankAccountNumber);

public record GetCustomersByPageResult(IPageList<CustomerDto> Customers);

public record GetCustomersByPageRequestDto
    (int PageNumber, int PageSize, string? Filters, string? SortOrder) : IPageRequest;

public record GetCustomersByPageResponseDto(IPageList<CustomerDto> Customers);