using Calculation.Api.Services.Taxes.Handlers;

namespace Calculation.Api.Services.Taxes;

public class TaxesBetweenTwelveTwentyFourMonthsCalculator : TaxesCalculatorHandler
{
    private const decimal TAX_BETWEEN_TWELVE_TWENTYFOUR_MONTHS = 0.175m;

    public override decimal GetTaxValue(decimal grossValue, int months)
    {
        if (months is > 12 and <= 24)
        {
            return grossValue * TAX_BETWEEN_TWELVE_TWENTYFOUR_MONTHS;
        }

        return NextHandler.GetTaxValue(grossValue, months);

    }
}