using Mc2.CrudTest.Presentation.Server.Customers.Exceptions;
using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Shared.Core.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.DeleteCustomer;

public class DeleteCustomerHandler : ICommandHandler<DeleteCustomer, bool>
{
    private readonly CustomerDbContext _context;

    public DeleteCustomerHandler(CustomerDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCustomer request, CancellationToken cancellationToken)
    {

        var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken);

        if (customer is null)
        {
            throw new CustomerNotFoundException();
        }

        var deletedCustomer = await _context.Customers.ExecuteDeleteAsync();

        return deletedCustomer == 1;
    }
}