using FluentValidation;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.UpdateCustomer;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomer>
{

    public UpdateCustomerValidator()
    {
        RuleFor(customer => customer.FirstName)
            .NotEmpty();
        RuleFor(customer => customer.Lastname)
            .NotEmpty();

        RuleFor(customer => customer.PhoneNumber)
            .Must(BeValidMobileNumber)
            .WithMessage("Invalid mobile number");

        //RuleFor(p => p.PhoneNumber)
        //    .NotEmpty()
        //    .NotNull().WithMessage("Phone Number is required.")
        //    .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
        //    .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
        //    .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");

        RuleFor(customer => customer.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");


        RuleFor(customer => customer.BankAccountNumber)
            .NotEmpty().WithMessage("Bank account number is required.")
            .Matches(@"^\d+$").WithMessage("Bank account number must contain only digits.")
            .Length(10, 20).WithMessage("Bank account number must be between 10 and 20 digits.");
    }

    private bool BeValidMobileNumber(string phoneNumber)
    {
        PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
        try
        {
            PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, "IR");
            return phoneNumberUtil.IsValidNumber(number) && phoneNumberUtil.GetNumberType(number) == PhoneNumberType.MOBILE;
        }
        catch (NumberParseException)
        {
            return false;
        }
    }
}