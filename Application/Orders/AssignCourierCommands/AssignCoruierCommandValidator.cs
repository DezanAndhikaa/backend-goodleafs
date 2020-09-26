using FluentValidation;

namespace Application.Orders.AssignCourierCommands {
    public class AssignCoruierCommandValidator : AbstractValidator<AssignCourierCommand> {
        public AssignCoruierCommandValidator () {
            RuleFor (e => e.IdCourier)
                .NotEmpty ().WithMessage ("Id Courier is requried")
                .NotNull ().WithMessage ("Id Courier is requried");

            RuleFor (e => e.IdOrder)
                .NotEmpty ().WithMessage ("Id Courier is requried")
                .NotNull ().WithMessage ("Id Courier is requried");
        }
    }
}