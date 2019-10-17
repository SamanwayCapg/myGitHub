/**  DEVELOPED BY - AISHWARYA SARNA
 *  DATE OF CREATION - 10/10/2019
 *  EMPLOYEE MODULE 
 * 
*/


import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { EmployeeHomeComponent } from './employee-home/employee-home.component';
import { EmployeeRoutingModule } from './employee-routing.module';
import { TransactionsComponent } from './transactions/transactions.component';
import { CustomersComponent } from './customers/customers.component';


//decorator
@NgModule({
  declarations: [
    EmployeeHomeComponent,
    CustomersComponent,
    TransactionsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    EmployeeRoutingModule
  ],
  exports: [
    EmployeeRoutingModule,
    EmployeeHomeComponent,
    CustomersComponent,
    TransactionsComponent,
  ]
})
export class EmployeeModule { }

