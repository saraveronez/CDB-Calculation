import { Observable } from "rxjs";
import { CalculationModel } from "../domain/calculation-model";
import { UseCase } from "../base/use-case";
import { CalculationWebRepository } from "src/app/data/repositories/calculation-repository/calculation-repository";
import { Injectable } from "@angular/core";
import { InvestimentModel } from "../domain/investiment-model";

@Injectable({
  providedIn: 'root'
})

export class GetCalculationUseCase implements UseCase<InvestimentModel, CalculationModel> {

  constructor(private calcRepository: CalculationWebRepository) { }

  execute(params: InvestimentModel): Observable<CalculationModel> {
    return this.calcRepository.getCalculation(params);
  }
}