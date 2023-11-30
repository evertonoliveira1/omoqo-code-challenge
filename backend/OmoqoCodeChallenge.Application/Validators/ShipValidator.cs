using FluentValidation;
using FluentValidation.Results;
using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Application.Validators
{
    public class ShipValidator : AbstractValidator<Ship>
    {
        public ShipValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Length).GreaterThan(0).WithMessage("Length must be greater than 0");
            RuleFor(x => x.Width).GreaterThan(0).WithMessage("Width must be greater than 0");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required")
                .Matches(@"^[A-Z]{4}-\d{4}-[A-Z]\d$").WithMessage("Invalid Code. You must use the pattern: 'AAAA-1111-A1'");
        }

        public static ValidatorResult ValidateErrors(Ship ship)
        {
            ShipValidator validator = new ShipValidator();
            ValidationResult validationResult = validator.Validate(ship);

            if (!validationResult.IsValid)
            {
                string errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                string message = $"Failed validations: {errorMessage}";

                return new ValidatorResult
                {
                    IsValid = false,
                    Message = message,
                };
            }

            return new ValidatorResult { IsValid = true };
        }
    }
}