/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  ADMIN ROUTING MODULE
 * 
*/


import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { EmployeesComponent } from './employees/employees.component';
import { ViewCustomersComponent } from './view-customers/view-customers.component';

//ROUTES
const routes: Routes = [
  { path: "home", component: AdminHomeComponent },
  { path: "employees", component: EmployeesComponent },
  { path: "view-customers", component: ViewCustomersComponent },
  { path: "**", redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }


