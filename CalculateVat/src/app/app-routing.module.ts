import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CalculateComponent } from './calculate/calculate.component';

const routes: Routes = [
  {
    path: 'calculate',
    component: CalculateComponent,
    data: { title: 'Calculate' }
  },
  {
    path: '',
    redirectTo: '/calculate',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
