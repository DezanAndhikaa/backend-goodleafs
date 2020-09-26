using FluentValidation;

namespace Application.Admins.Commands.UpdateAdminCommands {
    public class UpdateAdminCommandValidator : AbstractValidator<UpdateAdminCommand> {
        public UpdateAdminCommandValidator () {
            RuleFor (e => e.Admin.Username)
                .NotEmpty ().WithMessage ("Username is required");
        }
    }
}