using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace Calculation.Api.Configurations.WebApi.Swagger;

[ExcludeFromCodeCoverage]
public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, string appName, string version = "v1")
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(version, new OpenApiInfo { Title = $"{appName} - {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}", Version = version });
            c.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerWithUI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}