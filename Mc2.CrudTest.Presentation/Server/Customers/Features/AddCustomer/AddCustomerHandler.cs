using Mc2.CrudTest.Presentation.Server.Customers.Exceptions;
using Mc2.CrudTest.Presentation.Server.Customers.Models;
using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Shared.Core.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;


public class AddCustomerHandler : ICommandHandler<AddCustomer, AddCustomerResult>
{
    private readonly CustomerDbContext _eCommerceDbContext;

    public AddCustomerHandler(CustomerDbContext eCommerceDbContext)
    {
        _eCommerceDbContext = eCommerceDbContext;
    }

    public async Task<AddCustomerResult> Handle(AddCustomer request, CancellationToken cancellationToken)
    {

        var product = await _eCommerceDbContext.Customers.SingleOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken);

        if (product is not null)
        {
            throw new CustomerAlreadyExistException();
        }

        var customerEntity = Customer.Create(request.Id, request.FirstName,
            request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email,
            request.BankAccountNumber);

        var newProduct = (await _eCommerceDbContext.Customers.AddAsync(customerEntity, cancellationToken)).Entity;

        return new AddCustomerResult(newProduct.Id);
    }
}