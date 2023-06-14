using Mc2.CrudTest.Presentation.Shared.Exception;

namespace Mc2.CrudTest.Presentation.Server.Customers.Exceptions;

public class EmailAlreadyExistException : BadRequestException
{
    public EmailAlreadyExistException() : base("Email already exist!")
    {
    }
}