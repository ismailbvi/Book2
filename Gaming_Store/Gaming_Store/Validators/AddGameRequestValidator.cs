using FluentValidation;
using Gaming_Store_Data.Request;

namespace Gaming_Store.Validators
{
    public class AddGameRequestValidator :
        AbstractValidator<AddGameRequest>
    {
        public AddGameRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("Dai mu");
            RuleFor(x => x.Developer.Length)
                .GreaterThan(5)
                .WithMessage("Minimum 5 characters")
                .LessThan(10).WithMessage("Maximum 10 characters");

        }
    }
}
