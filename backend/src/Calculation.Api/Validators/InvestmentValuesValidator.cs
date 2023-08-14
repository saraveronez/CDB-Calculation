using Calculation.Api.Dtos;
using FluentValidation;

namespace Calculation.Api.Validators;

public class InvestmentValuesValidator : AbstractValidator<InvestmentValues>
{
    public InvestmentValuesValidator()
    {
        RuleFor(x => x.InitialValue)
            .GreaterThan(0)
            .WithMessage("O valor de investimento deve ser maior que 0(zero)..")
            .NotEmpty()
            .WithMessage("o campo InitialValue deve conter um valor válido.");

        RuleFor(x => x.Months)
            .GreaterThan(0)
            .WithMessage("A quantidade de meses deve ser maior que 0(zero).")
            .NotEmpty()
            .WithMessage("O campo Months deve conter um valor válido.");
    }
}