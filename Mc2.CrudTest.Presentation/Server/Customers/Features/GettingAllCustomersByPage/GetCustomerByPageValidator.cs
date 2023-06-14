using FluentValidation;

namespace Mc2.CrudTest.Presentation.Server.Customers.Features.GettingAllCustomersByPage;

public class GetCustomerByPageValidator : AbstractValidator<GetCustomersByPage>
{
    public GetCustomerByPageValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page should at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize should at least greater than or equal to 1.");
    }
}