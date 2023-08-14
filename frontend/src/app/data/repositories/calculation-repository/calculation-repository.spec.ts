import { TestBed } from "@angular/core/testing";
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CalculationWebRepository } from "src/app/data/repositories/calculation-repository/calculation-repository";
import { InvestimentModel } from "src/app/core/domain/investiment-model";
import { CalculationModel } from "src/app/core/domain/calculation-model";

describe('CalculationWebRepository', () => {
  let repository: CalculationWebRepository;

  beforeEach(() => {
    TestBed.configureTestingModule({ imports: [HttpClientTestingModule] });
    repository = TestBed.inject(CalculationWebRepository);
  });

  it('should return values is valid', async () => {
    expect(repository).toBeTruthy();
    const httpMock = TestBed.inject(HttpTestingController);

    const request: InvestimentModel = 
      {
          initialValue: 1000,
          months : 12
      };

      const calculationResponse :CalculationModel =
      { 
          grossProfit: 123.08,
          grossValueTotal: 1123.08,
          netProfit: 98.47,
          netValueTotal: 1098.47,
          taxes: 24.62
      };

    repository.getCalculation(request).subscribe((result) => {
      expect(result.grossProfit).toBe(calculationResponse.grossProfit);
      expect(result.grossValueTotal).toBe(calculationResponse.grossValueTotal);
      expect(result.netProfit).toBe(calculationResponse.netProfit);
      expect(result.netValueTotal).toBe(calculationResponse.netValueTotal);
      expect(result.taxes).toBe(calculationResponse.taxes);
    });

    const mockRequest = httpMock.expectOne(`https://localhost:7298/api/calculation?initialValue=${request.initialValue}&months=${request.months}`);
    mockRequest.flush(calculationResponse);
  });
})
