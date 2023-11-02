using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateOrderItemValidator : AbstractValidator<OrderItemRequest>
    {
        public CreateOrderItemValidator()
        {
            RuleFor(request => request.ProductId)
                .NotEmpty().WithMessage("ProductId field is required.")
                .GreaterThan(0).WithMessage("A valid ProductId must be provided.");

            RuleFor(request => request.Quantity)
                .NotEmpty().WithMessage("Quantity field is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }

    public class UpdateOrderItemValidator : AbstractValidator<OrderItemUpdateRequest>
    {
        public UpdateOrderItemValidator()
        {
            RuleFor(request => request.Quantity)
                .NotEmpty().WithMessage("Quantity field is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
