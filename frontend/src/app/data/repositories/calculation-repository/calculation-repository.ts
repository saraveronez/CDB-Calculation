
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {HttpParams} from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CalculationModel } from 'src/app/core/domain/calculation-model';
import { InvestimentModel } from 'src/app/core/domain/investiment-model';
import { CalculationRepository } from 'src/app/core/repositories/calculation-repository';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})

export class CalculationWebRepository extends CalculationRepository {
  url = environment.apiCalculation + '/api/calculation';

  constructor(private httpClient: HttpClient) {
      super();
  }
  // Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Cache-Control':  'no-cache, no-store, must-revalidate, post- check=0, pre-check=0',
      Pragma: 'no-cache',
      Expires: '0'
     })
  };

  getCalculation(investiment: InvestimentModel): Observable<CalculationModel> {

    const option = { params: new HttpParams().set('initialValue', investiment.initialValue).set('months', investiment.months) };

    return this.httpClient
      .get<CalculationModel>(this.url, option)
  }
}
