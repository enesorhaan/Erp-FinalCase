using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateCompanyValidator : AbstractValidator<CompanyRequest>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email field cannot be empty.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password field cannot be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
