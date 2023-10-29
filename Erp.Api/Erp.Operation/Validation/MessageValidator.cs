using Erp.Dto;
using FluentValidation;

namespace Erp.Operation.Validation
{
    public class CreateMessageValidator : AbstractValidator<MessageRequest>
    {
        public CreateMessageValidator()
        {
            RuleFor(request => request.ReceiverId)
                .NotEmpty().WithMessage("ReceiverId field is required.")
                .GreaterThan(0).WithMessage("A valid ReceiverId must be provided.");

            RuleFor(request => request.Messages)
                .NotEmpty().WithMessage("Messages field is required.")
                .MaximumLength(500).WithMessage("Messages cannot exceed 500 characters in length.");
        }

    }
}
