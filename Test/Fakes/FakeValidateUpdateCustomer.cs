using AutoBogus;
using Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;

namespace Test.Fakes;

public class FakeValidateUpdateCustomer : AutoFaker<UpdateCustomer>
{
    public FakeValidateUpdateCustomer()
    {
        RuleFor(r => r.FirstName, _ => string.Empty);
        RuleFor(r => r.Lastname, _ => string.Empty);
        RuleFor(r => r.DateOfBirth, _ => DateTime.MinValue);
        RuleFor(r => r.PhoneNumber, _ => string.Empty);
        RuleFor(r => r.Email, _ => string.Empty);
        RuleFor(r => r.BankAccountNumber, _ => string.Empty);
    }
}