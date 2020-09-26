using FluentValidation;

namespace Application.Users.Commands.CreateUserCommands {
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> {
        public CreateUserCommandValidator () {

            RuleFor (e => e.User.Address)
                .NotEmpty ().WithMessage ("User Address is Required")
                .NotNull ().WithMessage ("User Address is Required");

            RuleFor (e => e.User.Email)
                .NotEmpty ().WithMessage ("User Email is Required")
                .NotNull ().WithMessage ("User Email is Required");

            RuleFor (e => e.User.Gender)
                .NotNull ().WithMessage ("User Gender is Required");

            RuleFor (e => e.User.Name)
                .NotEmpty ().WithMessage ("User Name is Required")
                .NotNull ().WithMessage ("User Name is Required");

            RuleFor (e => e.User.Password)
                .NotEmpty ().WithMessage ("User Password is Required")
                .NotNull ().WithMessage ("User Password is Required");

            RuleFor (e => e.User.Phone)
                .NotEmpty ().WithMessage ("User Phone is Required")
                .NotNull ().WithMessage ("User Phone is Required");

            RuleFor (e => e.User.ZipCode)
                .NotEmpty ().WithMessage ("User ZipCode is Required")
                .NotNull ().WithMessage ("User ZipCode is Required");

            RuleFor (e => e.Image)
                .NotEmpty ().WithMessage ("User Profile is Required")
                .NotNull ().WithMessage ("User Profile is Required");

        }
    }
}