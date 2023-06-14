using Mc2.CrudTest.Presentation.Shared.Core.Pagination;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.GettingAllCustomersByPage;

public record GetCustomersByPage
        (int PageNumber, int PageSize, string? Filters, string? SortOrder) : IPageQuery<GetCustomersByPageResult>;


