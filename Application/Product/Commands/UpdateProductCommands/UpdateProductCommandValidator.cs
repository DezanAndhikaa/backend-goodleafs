using FluentValidation;

namespace Application.Product.Commands.UpdateProductCommands {
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand> {
        public UpdateProductCommandValidator () {
            RuleFor (v => v.Product.CategoryName)
                .NotEmpty ().WithMessage ("Category Is Required")
                .NotNull ().WithMessage ("Category Is Required");

            RuleFor (v => v.Product.Cost)
                .NotEmpty ().WithMessage ("Cost Is Required")
                .NotNull ().WithMessage ("Cost Is Required");

            RuleFor (v => v.Product.IsAvailable)
                .NotNull ().WithMessage ("IsAvailable is Required");

            RuleFor (v => v.Product.ProductName)
                .NotEmpty ().WithMessage ("ProductName Is Required")
                .NotNull ().WithMessage ("ProductName Is Required");

            RuleFor (v => v.Product.Stock)
                .NotEmpty ().WithMessage ("Stock Is Required")
                .NotNull ().WithMessage ("Stock Is Required");

            RuleFor (v => v.Product.VariantName)
                .NotEmpty ().WithMessage ("VariantName Is Required")
                .NotNull ().WithMessage ("VariantName Is Required");

            RuleFor (v => v.Product.Description)
                .NotEmpty ().WithMessage ("Description Is Required")
                .NotNull ().WithMessage ("Description Is Required");
        }
    }
}