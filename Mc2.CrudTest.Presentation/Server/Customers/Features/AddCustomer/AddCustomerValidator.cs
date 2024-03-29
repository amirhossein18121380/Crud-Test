﻿using FluentValidation;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.AddCustomer;

public class AddCustomerValidator : AbstractValidator<AddCustomer>
{
    public AddCustomerValidator()
    {
        RuleFor(customer => customer.FirstName)
            .NotEmpty();
        RuleFor(customer => customer.Lastname)
            .NotEmpty();

        RuleFor(customer => customer.PhoneNumber)
            .Must(BeValidMobileNumber)
            .WithMessage("Invalid mobile number");

        RuleFor(customer => customer.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");


        RuleFor(customer => customer.BankAccountNumber)
            .NotEmpty().WithMessage("Bank account number is required.")
            .Matches(@"^\d+$")//contains only digits
            .WithMessage("Bank account number must contain only digits.")
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