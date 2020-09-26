using FluentValidation;

namespace Application.Admins.Commands.DeleteAdminCommands {
    public class DeleteAdminCommandValidator : AbstractValidator<DeleteAdminCommand> {
        public DeleteAdminCommandValidator () {
            RuleFor (e => e.Username)
                .NotNull ().WithMessage ("username is Required")
                .NotEmpty ().WithMessage ("username is Required");
        }

    }
}