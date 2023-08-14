using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Calculation.Api.Configurations.HealthChecks;

[ExcludeFromCodeCoverage]
public class DependencyInjectionHealthCheck : IHealthCheck
{
    private IServiceProvider ServiceProvider { get; set; }

    public DependencyInjectionHealthCheck(IServiceProvider serviceProvider)
        => ServiceProvider = serviceProvider;

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var erros = new List<string>();
        var controllers = Assembly.GetCallingAssembly()
            .GetTypes()
            .Where(x => string.IsNullOrWhiteSpace(x.Namespace))
            .Where(x => x.IsClass)
            .Where(x => x.Name.Contains("Controller") && x.Name.Contains("Service") && x.Name.Contains("Repository"))
            .ToList();

        foreach (var controller in controllers)
        {
            try
            {
                ActivatorUtilities.CreateInstance(ServiceProvider, controller);
            }
            catch (Exception ex)
            {
                erros.Add($"Erro ao instanciar controller: {controller.Name} - Detalhe: {ex.Message}");
            }
        }

        var status = erros.Any() ? HealthStatus.Unhealthy : HealthStatus.Healthy;
        var healthCheckResult = new HealthCheckResult(status: status, description: string.Join(", ", erros));
        return await Task.FromResult(healthCheckResult);
    }
}