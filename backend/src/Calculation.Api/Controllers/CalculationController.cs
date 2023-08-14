using Calculation.Api.Dtos;
using Calculation.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculationController : ControllerBase
{
    private readonly ICalculationCdbService _cdbService;

    public CalculationController(ICalculationCdbService cdbService)
        => _cdbService = cdbService;

    [HttpGet]
    public IActionResult Calculate([FromQuery] InvestmentValues investmentValues)
        => Ok(_cdbService.CalculateCdb(investmentValues));
}