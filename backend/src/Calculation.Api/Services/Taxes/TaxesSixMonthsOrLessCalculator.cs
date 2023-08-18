using Calculation.Api.Services.Taxes.Handlers;

namespace Calculation.Api.Services.Taxes;

public class TaxesSixMonthsOrLessCalculator : TaxesCalculatorHandler
{
    private const decimal TAX_FOR_SIX_MONTHS = 0.225m;

    public TaxesSixMonthsOrLessCalculator() => SetNext(new TaxesBetweenSixTwelveMonthsCalculator());

    public override decimal GetTaxValue(decimal grossValue, int months)
    {
        if (months <= 6)
        {
            return grossValue * TAX_FOR_SIX_MONTHS;
        }

        return NextHandler.GetTaxValue(grossValue, months);

    }
}