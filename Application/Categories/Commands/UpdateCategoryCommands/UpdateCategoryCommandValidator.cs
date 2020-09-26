using FluentValidation;

namespace Application.Categories.Commands.UpdateCategoryCommands {
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand> {
        public UpdateCategoryCommandValidator () {
            RuleFor (e => e.Category.IdCategory)
                .NotEmpty ().WithMessage ("Username is required");
        }
    }
}