import { InvestimentModel } from './../domain/investiment-model';

export function validateCalculation(investimentModel: InvestimentModel): Array<string> {
  const errorMessages = new Array<string>()

  if (!(investimentModel.initialValue > 0))
  {
    errorMessages.push("O valor do investimento deve ser maior que 0(zero).")
  }

  if (!(investimentModel.months > 0))
  {
    errorMessages.push("O número de meses deve ser maior que 0(zero).")
  }

  return errorMessages;
}