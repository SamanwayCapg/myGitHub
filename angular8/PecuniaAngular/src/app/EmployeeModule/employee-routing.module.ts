/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  EMPLOYEE ROUTING MODULE 
 * 
*/



import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeHomeComponent } from './employee-home/employee-home.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { CustomersComponent } from './customers/customers.component';

//Routes
const routes: Routes = [
  { path: "home", component: EmployeeHomeComponent },
  { path: "transactions", component: TransactionsComponent },
  { path: "customers", component: CustomersComponent },
  { path: "loans", loadChildren: () => import("./loans-module/loan.module").then(m => m.LoanModule) },
  { path: "**", redirectTo: '/home', pathMatch: 'full' },
];


//decorator
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }


