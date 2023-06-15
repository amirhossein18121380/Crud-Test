using AutoBogus;
using Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;

namespace Test.Fakes;

public sealed class FakeUpdateCustomerCommand : AutoFaker<UpdateCustomer>
{
    public FakeUpdateCustomerCommand()
    {
        RuleFor(r => r.Id, _ => 15994298088341620177);
        RuleFor(r => r.FirstName, r => "Updated");
        RuleFor(r => r.Lastname, r => "ron");
        RuleFor(r => r.DateOfBirth, r => DateTime.Now.AddYears(10));
        RuleFor(r => r.PhoneNumber, r => "03972598475");
        RuleFor(r => r.Email, r => "alex@gmail.com");
        RuleFor(r => r.BankAccountNumber, r => "1234567895");
    }
}

