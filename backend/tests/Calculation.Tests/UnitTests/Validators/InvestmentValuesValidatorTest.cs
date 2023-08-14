using Calculation.Api.Dtos;
using Calculation.Api.Validators;
using FluentAssertions;

namespace Calculation.Tests.UnitTests.Validators;

[Trait("Validators", "InvestmentValuesValidator")]
public class InvestmentValuesValidatorTest
{
    [Theory(DisplayName = "Should return isValid")]
    [InlineData(1000, 1)]
    [InlineData(1000, 6)]
    [InlineData(9876, 12)]
    public void InvestmentValuesValidator_Should_ReturnIsValid(decimal initialValue, int months)
    {
        // Arrange
        var investiment = new InvestmentValues
        {
            InitialValue = initialValue,
            Months = months
        };

        // act
        var validator = new InvestmentValuesValidator();
        var result = validator.Validate(investiment);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }

    [Theory(DisplayName = "Should return invalid")]
    [InlineData(-1000, 1)]
    [InlineData(1000, 0)]
    [InlineData(0, -12)]
    public void InvestmentValuesValidator_Should_ReturnInValid(decimal initialValue, int months)
    {
        // Arrange
        var investiment = new InvestmentValues
        {
            InitialValue = initialValue,
            Months = months
        };

        // act
        var validator = new InvestmentValuesValidator();
        var result = validator.Validate(investiment);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
    }
}