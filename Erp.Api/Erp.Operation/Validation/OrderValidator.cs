using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateOrderValidator : AbstractValidator<OrderCreateRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(request => request.PaymentMethod)
                .NotEmpty().WithMessage("PaymentMethod field is required.");
        }
    }

    public class UpdateOrderValidator : AbstractValidator<OrderUpdateRequest>
    {
        public UpdateOrderValidator()
        {
            RuleFor(request => request.OrderStatus)
                .NotEmpty().WithMessage("OrderStatus field is required.");
        }
    }
}
