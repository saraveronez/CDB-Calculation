import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataModule } from '../data/data.modules';
import { CoreModule } from '../core/core.module';
import { CalculationComponent } from './pages/calculation/calculation.component';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    DataModule
  ],
  declarations: [
   CalculationComponent
  ],
  exports: [
    CalculationComponent
  ],
  providers: [],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})

export class PresentationModule {}