import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShowLoanComponent } from './ShowLoan/showLoan.component';
import { ApproveLoanComponent } from './ApproveLoan/approveLoan.component';
import { ApplyHomeLoanComponent } from './ApplyHomeLoan/applyHomeLoan.component';
import { ApplyCarLoanComponent } from './ApplyCarLoan/applyCarLoan.component';
import { ApplyEduLoanComponent } from './ApplyEduLoan/applyEduLoan.component';
import { LoanComponent } from './Loan/loan.component';


const routes: Routes = [
  { path: "showLoans", component: ShowLoanComponent },
  { path: "approveloans", component:ApproveLoanComponent },
  { path: "applycarloan", component: ApplyCarLoanComponent },
  { path: "applyhomeloan", component: ApplyHomeLoanComponent },
  { path: "applyeduloan", component: ApplyEduLoanComponent },
  { path: "loan", component: LoanComponent },
  //{ path: "", redirectTo: "ApplyNewLoan", pathMatch: "full" },
  { path: "**", redirectTo: "applyeduloan", pathMatch: "full" },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes, { useHash: true })],
  exports: [RouterModule]
})
export class LoanRoutingModule {

}
