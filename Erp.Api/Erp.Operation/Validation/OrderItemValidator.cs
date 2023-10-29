using Erp.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Erp.Operation.Validation
{
    public class CreateOrderItemValidator : AbstractValidator<OrderItemRequest>
    {
        public CreateOrderItemValidator()
        {
            RuleFor(request => request.OrderId)
                .NotEmpty().WithMessage("OrderId field is required.")
                .GreaterThan(0).WithMessage("A valid OrderId must be provided.");

            RuleFor(request => request.ProductId)
                .NotEmpty().WithMessage("ProductId field is required.")
                .GreaterThan(0).WithMessage("A valid ProductId must be provided.");

            RuleFor(request => request.MarginPrice)
                .NotEmpty().WithMessage("MarginPrice field is required.")
                .GreaterThanOrEqualTo(0).WithMessage("MarginPrice must be greater than or equal to 0.");

            RuleFor(request => request.Quantity)
                .NotEmpty().WithMessage("Quantity field is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
