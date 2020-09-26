using FluentValidation;

namespace Application.Categories.Commands.DeleteCategoryCommands {
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand> {
        public DeleteCategoryCommandValidator () {
            RuleFor (e => e.Id)
                .NotNull ().WithMessage ("id is Required")
                .NotEmpty ().WithMessage ("id is Required");
        }

    }
}