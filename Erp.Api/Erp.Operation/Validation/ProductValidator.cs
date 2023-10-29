using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateProductValidator : AbstractValidator<ProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(request => request.CompanyId)
                .NotEmpty().WithMessage("CompanyId field is required.")
                .GreaterThan(0).WithMessage("A valid CompanyId must be provided.");

            RuleFor(request => request.ProductName)
                .NotEmpty().WithMessage("ProductName field is required.")
                .MaximumLength(50).WithMessage("ProductName cannot exceed 50 characters in length.");

            RuleFor(request => request.ProductPrice)
                .NotEmpty().WithMessage("ProductPrice field is required.")
                .GreaterThan(0).WithMessage("ProductPrice must be greater than 0.");

            RuleFor(request => request.ProductStock)
                .NotEmpty().WithMessage("ProductStock field is required.")
                .GreaterThanOrEqualTo(0).WithMessage("ProductStock must be greater than or equal to 0.");
        }
    }
}
