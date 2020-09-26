using FluentValidation;

namespace Application.Users.Commands.UpdateUserCommands {
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand> {
        public UpdateUserCommandValidator () {
            RuleFor (e => e.User.UserId)
                .NotEmpty ().WithMessage ("IdDiscount is required");
        }
    }
}