using FluentValidation;
using Gaming_Store_Data.GameDto;

namespace GamingStore2.Validators
{
    public class AddGameValidator : AbstractValidator<CreateGameDto>
    {
        public AddGameValidator()
        {
            RuleFor(game => game.Name)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(game => game.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(game => game.Price)
                .NotEmpty().WithMessage("Release date is required.");
        }
    }
}
