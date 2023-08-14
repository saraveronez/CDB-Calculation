using Calculation.Api.Dtos;

namespace Calculation.Api.Services;

public interface ICalculationCdbService
{
    CdbCalculationResult CalculateCdb(InvestmentValues investmentValues);
}