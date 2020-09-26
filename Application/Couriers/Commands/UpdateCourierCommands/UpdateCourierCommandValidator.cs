using FluentValidation;

namespace Application.Couriers.Commands.UpdateCourierCommands {
    public class UpdateCourierCommandValidator : AbstractValidator<UpdateCourierCommand> {
        public UpdateCourierCommandValidator () {
            RuleFor (e => e.Courier.IdCourier)
                .NotEmpty ().WithMessage ("IdCourier is required");
        }
    }
}