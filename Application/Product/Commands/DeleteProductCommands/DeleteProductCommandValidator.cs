using FluentValidation;

namespace Application.Product.Commands.DeleteProductCommands {
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand> {
        public DeleteProductCommandValidator () {
            RuleFor (v => v.IdProduct)
                .NotEmpty ().WithMessage ("Category Is Required")
                .NotNull ().WithMessage ("Category Is Required");
        }
    }
}