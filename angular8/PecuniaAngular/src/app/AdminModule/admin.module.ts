/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  ADMIN MODULE 
 * 
*/


import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { EmployeesComponent } from './employees/employees.component';
import { AdminRoutingModule } from './admin-routing.module';
import { ViewCustomersComponent } from './view-customers/view-customers.component';


//DECORATOR
@NgModule({
  declarations: [
    AdminHomeComponent,
    EmployeesComponent,
    ViewCustomersComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AdminRoutingModule
  ],
  exports: [
    AdminRoutingModule,
    AdminHomeComponent,
    EmployeesComponent,
    ViewCustomersComponent
  ]
})
export class AdminModule { }

