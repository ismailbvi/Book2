using FluentValidation;
using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;

namespace Gaming_Store.Validators
{
    public class AddOrderValidator : AbstractValidator<AddOrderRequest>
    {
        public AddOrderValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();
            RuleFor(x => x.Address)
                .NotNull().NotEmpty(    )
                .Length(5);  
        }
    }
}
