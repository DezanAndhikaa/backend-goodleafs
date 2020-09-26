using FluentValidation;

namespace Application.Discounts.Commands.CreateDiscountCommands {
    public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand> {
        public CreateDiscountCommandValidator () {

            RuleFor (e => e.DiscountDto.DiscountName)
                .NotEmpty ().WithMessage ("Discount Name is Required")
                .NotNull ().WithMessage ("Discount Name is Required");

            RuleFor (e => e.DiscountDto.Content)
                .NotEmpty ().WithMessage ("Discount Content is Required")
                .NotNull ().WithMessage ("Discount Content is Required");

            RuleFor (e => e.DiscountDto.DiscountEnd)
                .NotEmpty ().WithMessage ("Discount End is Required")
                .NotNull ().WithMessage ("Discount End is Required");

            RuleFor (e => e.DiscountDto.DiscountStart)
                .NotEmpty ().WithMessage ("Discount Start is Required")
                .NotNull ().WithMessage ("Discount Start is Required");

            RuleFor (e => e.DiscountDto.DiscountType)
                .NotEmpty ().WithMessage ("Discount Type is Required")
                .NotNull ().WithMessage ("Discount Type is Required");

            RuleFor (e => e.DiscountBanner)
                .NotEmpty ().WithMessage ("Discount Banner is Required")
                .NotNull ().WithMessage ("Discount Banner is Required");

        }
    }
}