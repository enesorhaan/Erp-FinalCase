using FluentValidation;
using Erp.Dto;

namespace Erp.Operation.Validation;

public class CreateLoginValidator : AbstractValidator<LoginRequest>
{
    public CreateLoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
            .MinimumLength(5).WithMessage("Password must be at least 5 characters long");
    }
}