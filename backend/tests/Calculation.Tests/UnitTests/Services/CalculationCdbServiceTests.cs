using Calculation.Api.Dtos;
using Calculation.Api.Services;
using FluentAssertions;

namespace Calculation.Tests.UnitTests.Services;

[Trait("Services", "CalculationCdbService")]
public class CalculationCdbServiceTests
{
    [Theory(DisplayName = "Should return a net value total corretly")]
    [InlineData(1000, 1, 1007.53)]
    [InlineData(1000, 6, 1046.31)]
    [InlineData(1000, 12, 1098.47)]
    [InlineData(1000, 16, 1138.10)]
    [InlineData(1000, 25, 1232.54)]
    public void ShouldReturnNetValueTotalCurretly(decimal initalValue, int months, decimal netValueTotal)
    {
        // Arrange
        var service = new CalculationCdbService();
        var investimentValues = new InvestmentValues()
        {
            InitialValue = initalValue,
            Months = months
        };

        // Act
        var cdbCalculationResult = service.CalculateCdb(investimentValues);

        // Assert
        cdbCalculationResult.NetValueTotal.Should().Be(netValueTotal);
    }

    [Theory(DisplayName = "Should return a net profit corretly")]
    [InlineData(1000, 1, 7.53)]
    [InlineData(1000, 6, 46.31)]
    [InlineData(1000, 12, 98.47)]
    [InlineData(1000, 16, 138.1)]
    [InlineData(1000, 25, 232.54)]
    public void ShouldReturnNetProfitCurretly(decimal initalValue, int months, decimal netProfit)
    {
        // Arrange
        var service = new CalculationCdbService();
        var investimentValues = new InvestmentValues()
        {
            InitialValue = initalValue,
            Months = months
        };

        // Act
        var cdbCalculationResult = service.CalculateCdb(investimentValues);

        // Assert
        cdbCalculationResult.NetProfit.Should().Be(netProfit);
    }

    [Theory(DisplayName = "Should return a gross value total corretly")]
    [InlineData(1000, 1, 1009.72)]
    [InlineData(1000, 6, 1059.76)]
    [InlineData(1000, 12, 1123.08)]
    [InlineData(1000, 16, 1167.39)]
    [InlineData(1000, 25, 1273.57)]
    public void ShouldReturnGrossValueTotalCurretly(decimal initalValue, int months, decimal grossValueTotal)
    {
        // Arrange
        var service = new CalculationCdbService();
        var investimentValues = new InvestmentValues()
        {
            InitialValue = initalValue,
            Months = months
        };

        // Act
        var cdbCalculationResult = service.CalculateCdb(investimentValues);

        // Assert
        cdbCalculationResult.GrossValueTotal.Should().Be(grossValueTotal);
    }

    [Theory(DisplayName = "Should return a gross value corretly")]
    [InlineData(1000, 1, 9.72)]
    [InlineData(1000, 6, 59.76)]
    [InlineData(1000, 12, 123.08)]
    [InlineData(1000, 16, 167.39)]
    [InlineData(1000, 25, 273.57)]
    public void ShouldReturnGrossValueCurretly(decimal initalValue, int months, decimal grossValue)
    {
        // Arrange
        var service = new CalculationCdbService();
        var investimentValues = new InvestmentValues()
        {
            InitialValue = initalValue,
            Months = months
        };

        // Act
        var cdbCalculationResult = service.CalculateCdb(investimentValues);

        // Assert
        cdbCalculationResult.GrossProfit.Should().Be(grossValue);
    }

    [Theory(DisplayName = "Should return a taxes corretly")]
    [InlineData(1000, 1, 2.19)]
    [InlineData(1000, 6, 13.45)]
    [InlineData(1000, 12, 24.62)]
    [InlineData(1000, 16, 29.29)]
    [InlineData(1000, 25, 41.04)]
    public void ShouldReturnTaxesCurretly(decimal initalValue, int months, decimal taxes)
    {
        // Arrange
        var service = new CalculationCdbService();
        var investimentValues = new InvestmentValues()
        {
            InitialValue = initalValue,
            Months = months
        };

        // Act
        var cdbCalculationResult = service.CalculateCdb(investimentValues);

        // Assert
        cdbCalculationResult.Taxes.Should().Be(taxes);
    }
}