using FluentValidation;

namespace Application.Users.Commands.DeleteUserCommands {
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand> {
        public DeleteUserCommandValidator () {
            RuleFor (e => e.Id)
                .NotNull ().WithMessage ("id is Required")
                .NotEmpty ().WithMessage ("id is Required");
        }

    }
}