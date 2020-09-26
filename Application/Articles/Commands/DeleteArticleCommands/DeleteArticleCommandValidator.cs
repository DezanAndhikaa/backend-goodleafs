using FluentValidation;

namespace Application.Articles.Commands.DeleteArticleCommands {
    public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand> {
        public DeleteArticleCommandValidator () {
            RuleFor (e => e.Id)
                .NotNull ().WithMessage ("Id Article is Required")
                .NotEmpty ().WithMessage ("Id Article is Required");
        }

    }
}