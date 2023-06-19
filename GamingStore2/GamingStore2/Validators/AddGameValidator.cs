using FluentValidation;
using Gaming_Store_Data.Request;

namespace GamingStore2.Validators
{
    public class AddGameValidator : AbstractValidator<AddGameRequest>
    {
        public AddGameValidator()
        {
            RuleFor(game => game.Spacification)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(game => game.Description)
                .NotEmpty().WithMessage("Release date is required.");
        }
    }
}
