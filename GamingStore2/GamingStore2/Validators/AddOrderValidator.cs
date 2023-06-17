using FluentValidation;
using Gaming_Store_Data.GameDto;

namespace GamingStore2.Validators
{
    public class AddOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public AddOrderValidator()
        {
            RuleFor(order => order.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name must not exceed 100 characters.");

            RuleFor(order => order.GameId)
                .NotEmpty().WithMessage("Game ID is required.")
                .GreaterThan(0).WithMessage("Invalid Game ID.");

            RuleFor(order => order.Quantity)
                .NotEmpty().WithMessage("Quantity is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
