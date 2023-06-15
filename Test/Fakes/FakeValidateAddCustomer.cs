using AutoBogus;
using Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;

namespace Test.Fakes;

public class FakeValidateAddCustomer : AutoFaker<AddCustomer>
{
    public FakeValidateAddCustomer()
    {
        RuleFor(r => r.FirstName, _ => string.Empty);
        RuleFor(r => r.Lastname, _ => string.Empty);
        RuleFor(r => r.DateOfBirth, _ => DateTime.MinValue);
        RuleFor(r => r.PhoneNumber, _ => string.Empty);
        RuleFor(r => r.Email, _ => string.Empty);
        RuleFor(r => r.BankAccountNumber, _ => string.Empty);
    }
}
