using FluentValidation;

namespace Application.Couriers.Commands.CreateCourierCommands {
    public class CreateCourierCommandValidator : AbstractValidator<CreateCourierCommand> {
        public CreateCourierCommandValidator () {

            RuleFor (e => e.Courier.CourierName)
                .NotEmpty ().WithMessage ("Courier Name is Required")
                .NotNull ().WithMessage ("Courier Name is Required");

            RuleFor (e => e.Courier.CourierArea)
                .NotEmpty ().WithMessage ("Courier Area is Required")
                .NotNull ().WithMessage ("Courier Area is Required");

            RuleFor (e => e.Courier.CourierPhoneNumber)
                .NotEmpty ().WithMessage ("Courier Phone is Required")
                .NotNull ().WithMessage ("Courier Phone is Required");

            RuleFor (e => e.Courier.CourierPlateNumber)
                .NotEmpty ().WithMessage ("Courier Plate Number is Required")
                .NotNull ().WithMessage ("Courier Plate Number is Required");
        }
    }
}