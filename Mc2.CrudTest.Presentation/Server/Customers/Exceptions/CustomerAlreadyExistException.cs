using Mc2.CrudTest.Presentation.Shared.Exception;

namespace Mc2.CrudTest.Presentation.Server.Customers.Exceptions;


public class CustomerAlreadyExistException : BadRequestException
{
    public CustomerAlreadyExistException() : base("Customer already exist!")
    {
    }
}
