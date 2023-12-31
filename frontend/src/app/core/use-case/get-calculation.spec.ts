import { CalculationWebRepository } from "src/app/data/repositories/calculation-repository/calculation-repository";
import { GetCalculationUseCase } from "./get-calculation";
import { TestBed } from "@angular/core/testing";
import { InvestimentModel } from "../domain/investiment-model";
import { CalculationModel } from "../domain/calculation-model";
import { BehaviorSubject } from "rxjs";

describe('GetCalculationUseCase', () => {
 
  let useCase: GetCalculationUseCase;
  let repositorySpy: jasmine.SpyObj<CalculationWebRepository>;
  
 
  beforeEach(() => {
    const spy = jasmine.createSpyObj('CalculationWebRepository', ['getCalculation']);

    TestBed.configureTestingModule({
      providers: [
        GetCalculationUseCase,
        { provide: CalculationWebRepository, useValue: spy }
      ]
    });
    useCase = TestBed.inject(GetCalculationUseCase);
    repositorySpy = TestBed.inject(CalculationWebRepository) as jasmine.SpyObj<CalculationWebRepository>;
  });

  it('should return values is valid', async () => {
    
    const calculationResponse :CalculationModel =
    { 
        grossProfit: 123.08,
        grossValueTotal: 1123.08,
        netProfit: 98.47,
        netValueTotal: 1098.47,
        taxes: 24.62
    };

    repositorySpy.getCalculation.and.returnValue(new BehaviorSubject<CalculationModel>(calculationResponse));

    const request: InvestimentModel = 
      {
          initialValue: 1000,
          months : 12
      };
      
      useCase.execute(request).subscribe((result) => {
        expect(result.grossProfit).toBe(calculationResponse.grossProfit);
        expect(result.grossValueTotal).toBe(calculationResponse.grossValueTotal);
        expect(result.netProfit).toBe(calculationResponse.netProfit);
        expect(result.netValueTotal).toBe(calculationResponse.netValueTotal);
        expect(result.taxes).toBe(calculationResponse.taxes);
      });

    });
});