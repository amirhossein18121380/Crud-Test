using AutoBogus;
using Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;
using Mc2.CrudTest.Presentation.Server.Extension;

namespace Test.Fakes;

public sealed class FakeAddCustomerCommand : AutoFaker<AddCustomer>
{
    public FakeAddCustomerCommand()
    {
        RuleFor(r => r.Id, _ => HelperExtensions.GenerateRandomULong());
        RuleFor(r => r.FirstName, r => "alex");
        RuleFor(r => r.Lastname, r => "ron");
        RuleFor(r => r.DateOfBirth, r => DateTime.Now);
        RuleFor(r => r.PhoneNumber, r => "03654859715");
        RuleFor(r => r.Email, r => "alex@gmail.com");
        RuleFor(r => r.BankAccountNumber, r => "1234567895");
    }
}

