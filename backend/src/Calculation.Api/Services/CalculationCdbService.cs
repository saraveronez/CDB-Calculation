using Calculation.Api.Dtos;
using Calculation.Api.Services.Taxes.Handlers;

namespace Calculation.Api.Services;

public class CalculationCdbService : ICalculationCdbService
{
    private const decimal TAX_BANK = 1.08m; // Taxa banco sobre CDI 108%
    private const decimal TAX_CDI = 0.009m; // Taxa CDI 0.9%

    private readonly ITaxesHandler _taxesHandler;

    public CalculationCdbService(ITaxesHandler taxesHandler) => _taxesHandler = taxesHandler;

    public CdbCalculationResult CalculateCdb(InvestmentValues investmentValues)
    {
        var valueFinalGross = investmentValues.InitialValue;

        for (var i = 0; i < investmentValues.Months; i++)
        {
            valueFinalGross *= 1 + (TAX_BANK * TAX_CDI);
        }

        var taxes = _taxesHandler.GetTaxValue(valueFinalGross - investmentValues.InitialValue, investmentValues.Months);

        return new CdbCalculationResult
        {
            GrossValueTotal = Math.Round(valueFinalGross, 2),
            NetValueTotal = Math.Round(valueFinalGross - taxes, 2),
            NetProfit = Math.Round((valueFinalGross - taxes) - investmentValues.InitialValue, 2),
            GrossProfit = Math.Round(valueFinalGross - investmentValues.InitialValue, 2),
            Taxes = Math.Round(taxes, 2)
        };
    }
}