using Calculation.Api.Services.Taxes.Handlers;

namespace Calculation.Api.Services.Taxes;

public class TaxesBetweenSixTwelveMonthsCalculator : TaxesCalculatorHandler
{
    private const decimal TAX_BETWEEN_SIX_TWELVE_MONTHS = 0.2m;

    public override decimal GetTaxValue(decimal grossValue, int months)
    {
        if (months is > 6 and <= 12)
        {
            return grossValue * TAX_BETWEEN_SIX_TWELVE_MONTHS;
        }

        return NextHandler.GetTaxValue(grossValue, months);

    }
}