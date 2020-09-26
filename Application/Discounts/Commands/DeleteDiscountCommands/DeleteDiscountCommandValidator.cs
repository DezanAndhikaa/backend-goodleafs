using FluentValidation;

namespace Application.Discounts.Commands.DeleteDiscountCommands {
    public class DeleteDiscountCommandValidator : AbstractValidator<DeleteDiscountCommand> {
        public DeleteDiscountCommandValidator () {
            RuleFor (e => e.Id)
                .NotNull ().WithMessage ("id is Required")
                .NotEmpty ().WithMessage ("id is Required");
        }

    }
}