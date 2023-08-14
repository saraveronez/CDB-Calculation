import { Observable } from 'rxjs';
import { CalculationModel } from '../domain/calculation-model';
import { InvestimentModel } from '../domain/investiment-model';

export abstract class CalculationRepository {
  abstract getCalculation(investiment: InvestimentModel): Observable<CalculationModel>;
}