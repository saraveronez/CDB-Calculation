import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculationComponent } from './presentation/pages/calculation/calculation.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CalculationRepository } from './core/repositories/calculation-repository';
import { CalculationWebRepository } from './data/repositories/calculation-repository/calculation-repository';


@NgModule({
  declarations: [
    AppComponent,
    CalculationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ {provide: CalculationRepository, useClass: CalculationWebRepository}],
  bootstrap: [AppComponent]
})
export class AppModule { }
