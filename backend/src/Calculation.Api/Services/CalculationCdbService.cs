using Calculation.Api.Dtos;

namespace Calculation.Api.Services;

public class CalculationCdbService : ICalculationCdbService
{
    private const decimal TAX_BANK = 1.08m; // Taxa banco sobre CDI 108%
    private const decimal TAX_CDI = 0.009m; // Taxa CDI 0.9%

    public CdbCalculationResult CalculateCdb(InvestmentValues investmentValues)
    {
        var valueFinalGross = investmentValues.InitialValue;

        for (var i = 0; i < investmentValues.Months; i++)
        {
            valueFinalGross *= 1 + (TAX_BANK * TAX_CDI);
        }

        var taxes = GetTaxValue(investmentValues.Months, valueFinalGross - investmentValues.InitialValue);

        return new CdbCalculationResult
        {
            GrossValueTotal = Math.Round(valueFinalGross, 2),
            NetValueTotal = Math.Round(valueFinalGross - taxes, 2),
            NetProfit = Math.Round((valueFinalGross - taxes) - investmentValues.InitialValue, 2),
            GrossProfit = Math.Round(valueFinalGross - investmentValues.InitialValue, 2),
            Taxes = Math.Round(taxes, 2)
        };
    }

    private static decimal GetTaxValue(int months, decimal grossValue)
    {
        var taxAumount = 0m;

        switch (months)
        {
            case <= 6: taxAumount = grossValue * 0.225m; break;
            case > 6 and <= 12: taxAumount = grossValue * 0.2m; break;
            case > 12 and <= 24: taxAumount = grossValue * 0.175m; break;
            case > 24: taxAumount = grossValue * 0.15m; break;
        }

        return taxAumount;
    }
}