using Calculation.Api.Configurations;
using Calculation.Api.Configurations.WebApi.Cors;
using Calculation.Api.Configurations.WebApi.Middlewares;
using Calculation.Api.Configurations.WebApi.Swagger;
using Calculation.Api.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Configuração de logging com o serilog
builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());

// Configura as rotas no padrão de caixa baixa
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger("Calculation.Api");
builder.Services.AddValidatorsFromAssembly(typeof(InvestmentValuesValidator).Assembly);
builder.Services.AddFluentValidationAutoValidation();

// Configuração do health check
builder.Services.AddHealthChecksConfiguration();

// Configuração de injeção de dependências
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddControllers();
builder.Services.AdicionarCors();

var app = builder.Build();

app.UseSwaggerWithUI();

app.UseHealthCheck();
app.UseHttpsRedirection();
app.UsarCors();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();
app.Run();

[ExcludeFromCodeCoverage]
public partial class Program { }