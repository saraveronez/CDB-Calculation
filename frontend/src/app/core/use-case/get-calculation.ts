import { Observable } from "rxjs";
import { CalculationModel } from "../domain/calculation-model";
import { UseCase } from "../base/use-case";
import { Injectable } from "@angular/core";
import { InvestimentModel } from "../domain/investiment-model";
import { CalculationRepository } from "../repositories/calculation-repository";

@Injectable({
  providedIn: 'root'
})

export class GetCalculationUseCase implements UseCase<InvestimentModel, CalculationModel> {

  constructor(private calcRepository: CalculationRepository) { }

  execute(params: InvestimentModel): Observable<CalculationModel> {
    return this.calcRepository.getCalculation(params);
  }
}