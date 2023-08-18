using Calculation.Api.Services.Taxes.Handlers;

namespace Calculation.Api.Services.Taxes;

public class TaxesGreaterThanTwentyfourMonthsCalculator : TaxesCalculatorHandler
{
    private const decimal TAX_GREATER_THAN_TWENTYFOUR_MONTHS = 0.15m;

    public override decimal GetTaxValue(decimal grossValue, int months)
    {
        if (months > 24)
        {
            return grossValue * TAX_GREATER_THAN_TWENTYFOUR_MONTHS;
        }

        return NextHandler.GetTaxValue(grossValue, months);
    }
}