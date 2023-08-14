using Calculation.Api.Controllers;
using Calculation.Api.Dtos;
using Calculation.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Calculation.Tests.UnitTests.Controllers;

[Trait("Controllers", "CalculationController")]
public class CalculationControllerTest
{
    [Fact]
    public void Calculate_Should_ReturnInvestimentoResponse()
    {
        // Arrange
        var request = new InvestmentValues
        {
            InitialValue = 1000,
            Months = 12
        };

        // Arrange
        var mockService = new Mock<ICalculationCdbService>();
        mockService.Setup(service => service.CalculateCdb(request))
            .Returns(new CdbCalculationResult());

        var controller = new CalculationController(mockService.Object);

        // Act
        var result = controller.Calculate(request) as ObjectResult;

        // Assert
        result.Should().NotBeNull();
        result?.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
}