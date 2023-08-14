using Calculation.Api.Dtos;
using Calculation.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Calculation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculationController : ControllerBase
{
    private readonly ICalculationCdbService _cdbService;
    private readonly ILogger<CalculationController> _logger;

    public CalculationController(
        ICalculationCdbService cdbService,
        ILogger<CalculationController> logger)
    {
        _cdbService = cdbService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Calculate([FromQuery] InvestmentValues investmentValues)
    {
        try
        {
            return Ok(_cdbService.CalculateCdb(investmentValues));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}