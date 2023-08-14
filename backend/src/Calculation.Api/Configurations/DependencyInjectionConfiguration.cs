using Calculation.Api.Services;
using System.Diagnostics.CodeAnalysis;

namespace Calculation.Api.Configurations;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        => services.AddScoped<ICalculationCdbService, CalculationCdbService>();
}