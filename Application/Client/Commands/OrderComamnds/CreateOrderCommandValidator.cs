using FluentValidation;

namespace Application.Client.Commands.OrderComamnds {
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand> {
        public CreateOrderCommandValidator () {
            RuleFor (e => e.EmailUser)
                .NotEmpty ().WithMessage ("Email is required")
                .NotNull ().WithMessage ("Email is required");

            RuleFor (e => e.IdProducts)
                .NotEmpty ().WithMessage ("Email is required")
                .NotNull ().WithMessage ("Email is required");
        }
    }
}