using Calculation.Api.Services;
using Calculation.Api.Services.Taxes;
using Calculation.Api.Services.Taxes.Handlers;
using System.Diagnostics.CodeAnalysis;

namespace Calculation.Api.Configurations;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<ICalculationCdbService, CalculationCdbService>();
        services.AddScoped<ITaxesHandler, TaxesSixMonthsOrLessCalculator>();
    }

}