using Calculation.Api.Controllers;
using Calculation.Api.Dtos;
using Calculation.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Calculation.Tests.UnitTests.Controllers;

[Trait("Controllers", "CalculationController")]
public class CalculationControllerTest
{
    [Fact(DisplayName = "Should be return 200")]
    public void Calculate_Should_Return200()
    {
        // Arrange
        var request = new InvestmentValues
        {
            InitialValue = 1000,
            Months = 12
        };

        // Arrange
        var mockLogger = new Mock<ILogger<CalculationController>>();
        var mockService = new Mock<ICalculationCdbService>();
        mockService.Setup(service => service.CalculateCdb(request))
            .Returns(new CdbCalculationResult());

        var controller = new CalculationController(mockService.Object, mockLogger.Object);

        // Act
        var result = controller.Calculate(request) as ObjectResult;

        // Assert
        result.Should().NotBeNull();
        result?.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact(DisplayName = "Should be return 500")]
    public void Calculate_Should_Return500()
    {
        // Arrange
        var request = new InvestmentValues();

        // Arrange
        var mockLogger = new Mock<ILogger<CalculationController>>();
        var mockService = new Mock<ICalculationCdbService>();
        mockService.Setup(service => service.CalculateCdb(request))
            .Throws(new Exception());

        var controller = new CalculationController(mockService.Object, mockLogger.Object);

        // Act
        var result = controller.Calculate(request) as ObjectResult;

        // Assert
        result?.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
    }
}