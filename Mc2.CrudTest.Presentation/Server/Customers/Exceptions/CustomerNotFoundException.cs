using Mc2.CrudTest.Presentation.Shared.Exception;

namespace Mc2.CrudTest.Presentation.Server.Customers.Exceptions;
public class CustomerNotFoundException : BadRequestException
{
    public CustomerNotFoundException() : base("Customer not found!")
    {
    }
}
