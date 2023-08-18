namespace Calculation.Api.Services.Taxes.Handlers;

public interface ITaxesHandler
{
    ITaxesHandler SetNext(ITaxesHandler handler);

    decimal GetTaxValue(decimal grossValue, int months);
}