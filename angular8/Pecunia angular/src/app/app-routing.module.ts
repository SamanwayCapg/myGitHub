import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApplyLoanComponent } from './Components/ApplyLoan/applyLoan.component';
import { ShowLoanComponent } from './Components/ShowLoan/showLoan.component';

const routes: Routes = [
  { path: "ApplyNewLoan", component: ApplyLoanComponent },
  { path: "ShowLoans", component: ShowLoanComponent },
  { path: "applyloanmodule", loadChildren: () => import("./ApplyLoanModule/applyLoan.module").then(m => m.ApplyLoanModule) },
  { path: "", redirectTo: "ApplyNewLoan", pathMatch: "full" },
  { path: "**", redirectTo: "ApplyNewLoan", pathMatch: "full" },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
