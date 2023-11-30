using OmoqoCodeChallenge.Application.Validators;
using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Test
{
    public class ShipValidatorUnitTest
    {
        [Fact(DisplayName = "Should return a validation error with 4 errors")]
        public void Validate_InvalidModelWithOnlyName_ShouldReturnErrorMessage()
        {
            Ship ship = new Ship
            {
                Name = "Ship 001"
            };

            ValidatorResult validatorResult = ShipValidator.ValidateErrors(ship);

            string errorMessage = "Failed validations: Length must be greater than 0, Width must be greater than 0, Code is required, Invalid Code. You must use the pattern: 'AAAA-1111-A1'";

            Assert.False(validatorResult.IsValid);
            Assert.Equal(validatorResult.Message, errorMessage);

        }

        [Fact(DisplayName = "Should return a validation error with 3 errors")]
        public void Validate_InvalidModelWithNameAndLength_ShouldReturnErrorMessage()
        {
            Ship ship = new Ship
            {
                Name = "Ship 001",
                Width = 10
            };

            ValidatorResult validatorResult = ShipValidator.ValidateErrors(ship);

            string errorMessage = "Failed validations: Length must be greater than 0, Code is required, Invalid Code. You must use the pattern: 'AAAA-1111-A1'";

            Assert.False(validatorResult.IsValid);
            Assert.Equal(validatorResult.Message, errorMessage);

        }

        [Fact(DisplayName = "Should return a validation error with Invalid code")]
        public void Validate_InvalidModelWithInvalidaCode_ShouldReturnErrorMessage()
        {
            Ship ship = new Ship
            {
                Name = "Ship 001",
                Width = 10,
                Length = 20,
                Code = "AAAAA"
            };

            ValidatorResult validatorResult = ShipValidator.ValidateErrors(ship);

            string errorMessage = "Failed validations: Invalid Code. You must use the pattern: 'AAAA-1111-A1'";

            Assert.False(validatorResult.IsValid);
            Assert.Equal(validatorResult.Message, errorMessage);
        }


        [Fact(DisplayName = "Should return success validation")]
        public void Validate_ValidModel_ShouldReturnSuccess()
        {
            Ship ship = new Ship
            {
                Name = "Ship 001",
                Width = 10,
                Length = 20,
                Code = "AAAA-1111-A1"
            };

            ValidatorResult validatorResult = ShipValidator.ValidateErrors(ship);

            Assert.True(validatorResult.IsValid);
        }

    }
}
