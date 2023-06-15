using Mc2.CrudTest.Presentation.Server.Customers.Exceptions;
using Mc2.CrudTest.Presentation.Server.Customers.Models;
using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Shared.Core.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;

public class UpdateCustomerHandler : ICommandHandler<UpdateCustomer, UpdateCustomerResult>
{
    private readonly CustomerDbContext _customerDbContext;

    public UpdateCustomerHandler(CustomerDbContext customerDbContext)
    {
        _customerDbContext = customerDbContext;
    }

    public async Task<UpdateCustomerResult> Handle(UpdateCustomer request, CancellationToken cancellationToken)
    {

        var customer = await _customerDbContext.Customers.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (customer is null) throw new CustomerNotFoundException();

        if (_customerDbContext.Customers.Any(x => x.Email == request.Email && x.Email != customer.Email)) throw new EmailAlreadyExistException();

        var customerEntity = Customer.Update(request.Id, request.FirstName,
            request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email,
        request.BankAccountNumber);

        var updatedCustomer = _customerDbContext.Customers.Update(customerEntity).Entity;
        await _customerDbContext.SaveChangesAsync();
        return new UpdateCustomerResult(customerEntity);
    }
}