import { TestBed } from '@angular/core/testing';
import { CalculationComponent } from './calculation.component';
import { GetCalculationUseCase } from 'src/app/core/use-case/get-calculation';
import { InvestimentModel } from 'src/app/core/domain/investiment-model';
import { CalculationModel } from 'src/app/core/domain/calculation-model';
import { Observable, of } from 'rxjs';

describe('CalculationComponent', () => {
  let component: CalculationComponent;
  let useCase: GetCalculationUseCase;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        CalculationComponent,
        { provide: GetCalculationUseCase, useClass: MockUseCase }
      ]
    });
    component = TestBed.inject(CalculationComponent);
    useCase = TestBed.inject(GetCalculationUseCase);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should return values is valid', async () => {
    component.initialValue = 1000;
    component.months = 10;
    component.getCalculo();

    expect(component.calc).not.toBeNull();
    expect(component.calc?.netProfit).toBe(98.47);
  });
})
class MockUseCase {

  calculationResponse :CalculationModel =
  { 
      grossProfit: 123.08,
      grossValueTotal: 1123.08,
      netProfit: 98.47,
      netValueTotal: 1098.47,
      taxes: 24.62
  };
  execute(params: InvestimentModel): Observable<CalculationModel> {
    return of(this.calculationResponse)
  }
}
