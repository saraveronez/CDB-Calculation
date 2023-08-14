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
  calc?: CalculationModel;
  errorMessages?: Array<string>;

  constructor(private getCalc: GetCalculationUseCase) {}

    // Atualiza a variável calc com o resultado
    getCalculo() {
      this.errorMessages = new Array<string>; 

      const requestData: InvestimentModel = {
        initialValue: this.initialValue,
        months: this.months
      };

      this.errorMessages = validateCalculation(requestData);
      if (this.errorMessages.length > 0) return;

      this.getCalc.execute(requestData).subscribe({
        next: (value) => this.calc = value,
        error: console.error
      });
    }
}
