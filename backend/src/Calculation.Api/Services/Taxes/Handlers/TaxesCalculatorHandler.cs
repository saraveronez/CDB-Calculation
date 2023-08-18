namespace Calculation.Api.Services.Taxes.Handlers;

public abstract class TaxesCalculatorHandler : ITaxesHandler
{
    protected ITaxesHandler NextHandler;

    public ITaxesHandler SetNext(ITaxesHandler handler)
    {
        NextHandler = handler;
        return handler;
    }

    public abstract decimal GetTaxValue(decimal grossValue, int months);
}