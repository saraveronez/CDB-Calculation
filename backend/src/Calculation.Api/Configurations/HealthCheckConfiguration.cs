using Calculation.Api.Configurations.HealthChecks;
using HealthChecks.UI.Core;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Calculation.Api.Configurations;

[ExcludeFromCodeCoverage]
public static class HealthCheckConfiguration
{
    public static IServiceCollection AddHealthChecksConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        var serviceProvider = services.BuildServiceProvider();

        services
            .AddHealthChecks()
            .AddCheck("DEPENDENCY_INJECTION", new DependencyInjectionHealthCheck(serviceProvider));

        return services;
    }

    public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app)
    {
        var options = new HealthCheckOptions
        {
            AllowCachingResponses = false,
            ResultStatusCodes =
            {
                [HealthStatus.Unhealthy] = StatusCodes.Status500InternalServerError
            },
            ResponseWriter = async (context, report) =>
            {
                var healthReport = UIHealthReport.CreateFrom(report);
                var response = JsonSerializer.Serialize(healthReport);
                await context.Response.WriteAsync(response);
            }
        };

        return app.UseHealthChecks("/healthz", options);
    }

}