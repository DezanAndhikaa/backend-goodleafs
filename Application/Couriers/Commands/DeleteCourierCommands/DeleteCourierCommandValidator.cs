using FluentValidation;

namespace Application.Couriers.Commands.DeleteCourierCommands {
    public class DeleteCourierCommandValidator : AbstractValidator<DeleteCourierCommand> {
        public DeleteCourierCommandValidator () {
            RuleFor (e => e.Id)
                .NotNull ().WithMessage ("id is Required")
                .NotEmpty ().WithMessage ("id is Required");
        }

    }
}