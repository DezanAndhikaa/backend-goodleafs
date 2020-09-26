using FluentValidation;

namespace Application.Admins.Commands.LoginAdminCommands {
    public class LoginCommandValidator : AbstractValidator<LoginAdmminCommand> {
        public LoginCommandValidator () {
            RuleFor (e => e.Password)
                .NotEmpty ().WithMessage ("Password is required")
                .NotNull ().WithMessage ("Password is required");

            RuleFor (e => e.Username)
                .NotEmpty ().WithMessage ("Username is required")
                .NotNull ().WithMessage ("Username is required");
        }
    }
}