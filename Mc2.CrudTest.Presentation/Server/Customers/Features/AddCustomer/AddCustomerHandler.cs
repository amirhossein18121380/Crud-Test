using Mc2.CrudTest.Presentation.Server.Customers.Exceptions;
using Mc2.CrudTest.Presentation.Server.Customers.Models;
using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Shared.Core.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;


public class AddCustomerHandler : ICommandHandler<AddCustomer, AddCustomerResult>
{
    private readonly CustomerDbContext _customerDbContext;

    public AddCustomerHandler(CustomerDbContext customerDbContext)
    {
        _customerDbContext = customerDbContext;
    }

    public async Task<AddCustomerResult> Handle(AddCustomer request, CancellationToken cancellationToken)
    {

        var customer = await _customerDbContext.Customers.SingleOrDefaultAsync(x => x.FirstName == request.FirstName
                || x.Lastname == request.Lastname
            || x.DateOfBirth == request.DateOfBirth,
            cancellationToken);

        if (customer is not null) throw new CustomerAlreadyExistException();

        if (_customerDbContext.Customers.Any(x => x.Email == request.Email)) throw new EmailAlreadyExistException();

        var customerEntity = Customer.Create(request.Id, request.FirstName,
            request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email,
            request.BankAccountNumber);

        var newProduct = (await _customerDbContext.Customers.AddAsync(customerEntity, cancellationToken)).Entity;

        await _customerDbContext.SaveChangesAsync();
        return new AddCustomerResult(newProduct.Id);
    }
}