using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateDealerValidator : AbstractValidator<DealerRequest>
    {
        public CreateDealerValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email field cannot be empty.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password field cannot be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.DealerName)
                .NotEmpty().WithMessage("Dealer name cannot be empty.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be empty.");

            RuleFor(x => x.BillingAddress)
                .NotEmpty().WithMessage("Billing address cannot be empty.");

            RuleFor(x => x.TaxOffice)
                .NotEmpty().WithMessage("Tax office cannot be empty.");

            RuleFor(x => x.TaxNumber)
                .NotEmpty().WithMessage("Tax number field cannot be empty.")
                .GreaterThan(0).WithMessage("Tax number must be greater than 0.");

            RuleFor(x => x.MarginPercentage)
                .InclusiveBetween(0, 100).WithMessage("Margin percentage must be between 0 and 100.");
        }
    }
}
