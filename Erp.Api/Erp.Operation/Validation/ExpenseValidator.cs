using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateExpenseValidator : AbstractValidator<ExpenseRequest>
    {
        public CreateExpenseValidator()
        {
            RuleFor(request => request.Description)
                .NotEmpty().WithMessage("Description field is required.")
                .MaximumLength(100).WithMessage("Description field must be maximum 100 characters.");

            RuleFor(request => request.Amount)
                .NotEmpty().WithMessage("Amount field is required.")
                .GreaterThan(0).WithMessage("A valid Amount must be provided.");

            RuleFor(request => request.ExpenseDate)
                .NotEmpty().WithMessage("ExpenseDate field is required.")
                .LessThan(System.DateTime.Now).WithMessage("A valid ExpenseDate must be provided.");
        }
    }
}
