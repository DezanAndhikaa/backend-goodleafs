using FluentValidation;

namespace Application.Admins.Commands.CreateAdminCommands {
    public class CreateAdminCommandValidator : AbstractValidator<CreateAdminCommand> {
        public CreateAdminCommandValidator () {

            RuleFor (e => e.Admin.Username)
                .NotEmpty ().WithMessage ("Admin Username is Required")
                .NotNull ().WithMessage ("Admin Username is Required");

            RuleFor (e => e.Admin.Password)
                .NotEmpty ().WithMessage ("Admin Password is Required")
                .NotNull ().WithMessage ("Admin Password is Required");
        }
    }
}