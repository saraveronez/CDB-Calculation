using System.Diagnostics.CodeAnalysis;

namespace Calculation.Api.Configurations.WebApi.Cors;

[ExcludeFromCodeCoverage]
public static class CorsConfiguration
{
    private const string POLICY_CORS_NAME = "PolicyCors";

    public static IServiceCollection AdicionarCors(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        return services.AddCors(
            options => options.AddPolicy(POLICY_CORS_NAME,
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));
    }

    public static IApplicationBuilder UsarCors(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));
        app.UseCors(POLICY_CORS_NAME);
        return app;
    }
}