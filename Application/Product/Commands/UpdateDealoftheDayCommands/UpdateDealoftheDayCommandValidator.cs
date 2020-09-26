using FluentValidation;

namespace Application.Product.Commands.UpdateDealoftheDayCommands {
    public class UpdateDealoftheDayCommandValidator : AbstractValidator<UpdateDealoftheDayCommand> {
        public UpdateDealoftheDayCommandValidator () {
            RuleFor (e => e.IdProducts)
                .NotEmpty ().WithMessage ("ID Products cant be empty!")
                .NotNull ().WithMessage ("ID Products cant be null!");
        }
    }
}