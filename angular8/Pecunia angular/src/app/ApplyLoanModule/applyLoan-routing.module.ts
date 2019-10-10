import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplyCarLoanComponent } from './ApplyCarLoan/applyCarLoan.component';

const routes: Routes = [
  { path: "applycarloan", component: ApplyCarLoanComponent },
  { path: "**", redirectTo: '/applycarloan', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplyLoanRoutingModule {

}
