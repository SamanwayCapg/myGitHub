import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplyCarLoanComponent } from './ApplyCarLoan/applyCarLoan.component';
import { ApplyEduLoanComponent } from './ApplyEduLoan/applyEduLoan.component';
import { ApplyHomeLoanComponent } from './ApplyHomeLoan/applyHomeLoan.component';

const routes: Routes = [
    { path: "applycarloan", component: ApplyCarLoanComponent },
    { path: "applyeduloan", component: ApplyEduLoanComponent },
    { path: "applyhomeloan", component: ApplyHomeLoanComponent },
  { path: "**", redirectTo: '/applycarloan', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplyLoanRoutingModule {

}
