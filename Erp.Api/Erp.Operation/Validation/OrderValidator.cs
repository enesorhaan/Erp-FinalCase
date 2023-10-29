using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateOrderValidator : AbstractValidator<OrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(request => request.DealerId)
                .NotEmpty().WithMessage("DealerId field is required.")
                .GreaterThan(0).WithMessage("A valid DealerId must be provided.");

            RuleFor(request => request.BillingNumber)
                .NotEmpty().WithMessage("BillingNumber field is required.")
                .MaximumLength(50).WithMessage("BillingNumber cannot exceed 50 characters in length.");

            RuleFor(request => request.TotalPrice)
                .NotEmpty().WithMessage("TotalPrice field is required.")
                .GreaterThan(0).WithMessage("TotalPrice must be greater than 0.");

            RuleFor(request => request.OrderDate)
                .NotEmpty().WithMessage("OrderDate field is required.");

            RuleFor(request => request.PaymentMethod)
                .NotEmpty().WithMessage("PaymentMethod field is required.");

            RuleFor(request => request.OrderStatus)
                .NotEmpty().WithMessage("OrderStatus field is required.");
        }
    }
}
