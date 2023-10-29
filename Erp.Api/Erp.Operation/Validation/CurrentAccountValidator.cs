using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateCurrentAccountValidator : AbstractValidator<CurrentAccountRequest>
    {
        public CreateCurrentAccountValidator()
        {
            RuleFor(x => x.DealerId)
                .NotEmpty().WithMessage("DealerId field is required.")
                .GreaterThan(0).WithMessage("A valid DealerId must be provided.");

            RuleFor(x => x.CreditLimit)
                .NotEmpty().WithMessage("CreditLimit field is required.")
                .GreaterThanOrEqualTo(0).WithMessage("CreditLimit must be 0 or greater.");
        }
    }
}
