import { Component  } from '@angular/core';
import { CalculationModel } from 'src/app/core/domain/calculation-model';
import { InvestimentModel } from 'src/app/core/domain/investiment-model';
import { GetCalculationUseCase } from 'src/app/core/use-case/get-calculation'
import { validateCalculation } from 'src/app/core/validators/calculation-validator';

@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.css']
})
export class CalculationComponent {
  public initialValue: number = 0;
  public months: number = 0;
  calculationModel?: CalculationModel;
  errorMessages?: Array<string>;

  constructor(private getCalculation: GetCalculationUseCase) {}

    // Atualiza a variável calc com o resultado
    getCalculo() {
      this.errorMessages = new Array<string>; 

      const requestData: InvestimentModel= new InvestimentModel(this.months, this.initialValue);

      this.errorMessages = validateCalculation(requestData);
      if (this.errorMessages.length > 0) return;

      this.getCalculation.execute(requestData).subscribe({
        next: (value) => this.calculationModel = value,
        error: console.error
      });
    }
}
