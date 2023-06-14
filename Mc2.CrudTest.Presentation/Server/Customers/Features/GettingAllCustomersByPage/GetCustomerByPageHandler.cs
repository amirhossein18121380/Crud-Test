using AutoMapper;
using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Shared.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.GettingAllCustomersByPage;

public class GetCustomerByPageHandler : IRequestHandler<GetCustomersByPage, GetCustomersByPageResult>
{
    private readonly ISieveProcessor _sieveProcessor;
    private readonly IMapper _mapper;
    private readonly CustomerDbContext _context;

    public GetCustomerByPageHandler(
        ISieveProcessor sieveProcessor,
        IMapper mapper,
        CustomerDbContext context
    )
    {
        _sieveProcessor = sieveProcessor;
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetCustomersByPageResult> Handle(GetCustomersByPage request, CancellationToken cancellationToken)
    {
        var pageList = await _context.Customers.AsNoTracking().ApplyPagingAsync(request, _sieveProcessor, cancellationToken);

        var result = _mapper.Map<PageList<CustomerDto>>(pageList);

        return new GetCustomersByPageResult(result);
    }
}
