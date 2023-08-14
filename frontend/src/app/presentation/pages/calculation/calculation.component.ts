import { Component  } from '@angular/core';
import { CalculationModel } from 'src/app/core/domain/calculation-model';
import { GetCalculationUseCase } from 'src/app/core/use-case/get-calculation'

@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.css']
})
export class CalculationComponent {
  public initialValue: number = 0;
  public months: number = 0;
  calc?: CalculationModel;

  constructor(private getCalc: GetCalculationUseCase) {}

    // Atualiza a variável calc com o resultado
    getCalculo() {
      const requestData = {
        initialValue: this.initialValue,
        months: this.months
      };

      this.getCalc.execute(requestData).subscribe({
        next: (value) => this.calc = value,
        error: console.error
      });
    }
}
