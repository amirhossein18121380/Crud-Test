using FluentValidation;
using Mc2.CrudTest.Presentation.Server.Customers.Models;
using Mc2.CrudTest.Presentation.Server.Data;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;

public class AddCustomerValidator : AbstractValidator<AddCustomer>
{

    private readonly CustomerDbContext _dbContext;

    public AddCustomerValidator(CustomerDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(customer => customer.PhoneNumber)
            .Must(BeValidMobileNumber)
            .WithMessage("Invalid mobile number");

        RuleFor(customer => customer.Email)
            .Must(BeUniqueEmail)
            .WithMessage("Email must be unique")
            .EmailAddress()
            .WithMessage("Invalid email address");

        RuleFor(customer => customer.BankAccountNumber)
            .Must(BeValidBankAccountNumber)
            .WithMessage("Invalid bank account number");

        RuleFor(customer => new { customer.FirstName, customer.Lastname, customer.DateOfBirth })
            .Must(BeUniqueCustomer)
            .WithMessage("Customer already exists");
    }

    private bool BeValidMobileNumber(string phoneNumber)
    {
        PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
        PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, null);
        return phoneNumberUtil.IsValidNumber(number) && phoneNumberUtil.GetNumberType(number) == PhoneNumberType.MOBILE;
    }

    private bool BeUniqueEmail(string email)
    {
        return !_dbContext.Customers.Any(customer => customer.Email == email);
    }

    private bool BeValidBankAccountNumber(string bankAccountNumber)
    {
        // Add your custom bank account number validation logic here
        return true;
    }

    private bool BeUniqueCustomer(object customerInfo)
    {
        var customer = (Customer)customerInfo;
        return !_dbContext.Customers.Any(c => c.FirstName == customer.FirstName &&
                                              c.Lastname == customer.Lastname &&
                                              c.DateOfBirth == customer.DateOfBirth);
    }
}