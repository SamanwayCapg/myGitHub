import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApplyLoanComponent } from './Components/ApplyLoan/applyLoan.component';
import { ShowLoanComponent } from './Components/ShowLoan/showLoan.component';
import { ApproveLoanComponent } from './Components/ApproveLoan/approveLoan.component';

const routes: Routes = [
  { path: "ApplyNewLoan", component: ApplyLoanComponent },
  { path: "showLoans", component: ShowLoanComponent },
    { path: "applyloanmodule", loadChildren: () => import("./ApplyLoanModule/applyLoan.module").then(m => m.ApplyLoanModule) },
    { path: "approveloans", component:ApproveLoanComponent },
  //{ path: "", redirectTo: "ApplyNewLoan", pathMatch: "full" },
  { path: "**", redirectTo: "ApplyNewLoan", pathMatch: "full" },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
