using FluentValidation;

namespace Application.Articles.Commands.CreateArticleCommands {
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand> {
        public CreateArticleCommandValidator () {

            RuleFor (e => e.Article.ArticleAuthor)
                .NotEmpty ().WithMessage ("Article Author is Required")
                .NotNull ().WithMessage ("Article Author is Required");

            RuleFor (e => e.Article.ArticleBody)
                .NotEmpty ().WithMessage ("Article Body is Required")
                .NotNull ().WithMessage ("Article Body is Required");

            RuleFor (e => e.Article.ArticleDate)
                .NotEmpty ().WithMessage ("Article Date is Required")
                .NotNull ().WithMessage ("Article Date is Required");

            RuleFor (e => e.Article.ArticleTitle)
                .NotEmpty ().WithMessage ("Article Title is Required")
                .NotNull ().WithMessage ("Article Title is Required");

            RuleFor (e => e.ArticleBanner)
                .NotEmpty ().WithMessage ("Article Banner is Required")
                .NotNull ().WithMessage ("Article Banner is Required");
        }
    }
}