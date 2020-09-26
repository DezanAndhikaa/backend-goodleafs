using FluentValidation;

namespace Application.Discounts.Commands.UpdateDiscountCommands {
    public class UpdateDiscountCommandValidator : AbstractValidator<UpdateDiscountCommand> {
        public UpdateDiscountCommandValidator () {
            RuleFor (e => e.DiscountDto.IdDiscount)
                .NotEmpty ().WithMessage ("IdDiscount is required");
        }
    }
}