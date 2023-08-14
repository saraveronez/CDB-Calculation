using System.Diagnostics.CodeAnalysis;

namespace Calculation.Api.Configurations.WebApi.Middlewares;

[ExcludeFromCodeCoverage]
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
        => _next = next;

    public async Task Invoke(HttpContext httpContext, ILogger<HttpContext> logger)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            httpContext.Response.StatusCode = 500;
        }
    }
}