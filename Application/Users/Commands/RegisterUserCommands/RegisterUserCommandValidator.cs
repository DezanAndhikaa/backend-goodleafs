using FluentValidation;

namespace Application.Users.Commands.RegisterUserCommands {
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand> {
        public RegisterUserCommandValidator () {

            RuleFor (e => e.Name)
                .NotEmpty ().WithMessage ("Name is Required")
                .NotNull ().WithMessage ("Name is Required");

            RuleFor (e => e.Email)
                .NotEmpty ().WithMessage ("User Email is Required")
                .NotNull ().WithMessage ("User Email is Required");

            RuleFor (e => e.Password)
                .NotEmpty ().WithMessage ("User Password is Required")
                .NotNull ().WithMessage ("User Password is Required");
        }
    }
}