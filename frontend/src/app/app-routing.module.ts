import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalculationComponent } from './presentation/pages/calculation/calculation.component';

const routes: Routes = [
  {
    path: 'calculation',
    component: CalculationComponent
  },
  {
    path: '',
    component: CalculationComponent
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
