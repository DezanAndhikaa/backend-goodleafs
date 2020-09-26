using FluentValidation;

namespace Application.Categories.Commands.CreateCategoryCommands {
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand> {
        public CreateCategoryCommandValidator () {

            RuleFor (e => e.Category.CategoryName)
                .NotEmpty ().WithMessage ("Category Name is Required")
                .NotNull ().WithMessage ("Category Name is Required");
        }
    }
}