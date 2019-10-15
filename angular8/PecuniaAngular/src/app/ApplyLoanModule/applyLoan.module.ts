import { NgModule } from '@angular/core';
import { ApplyCarLoanComponent } from './ApplyCarLoan/applyCarLoan.component';
import { ApplyEduLoanComponent } from './ApplyEduLoan/applyEduLoan.component';
import { ApplyHomeLoanComponent } from './ApplyHomeLoan/applyHomeLoan.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplyLoanRoutingModule } from '../ApplyLoanModule/applyLoan-routing.module';


@NgModule({
  declarations: [
        ApplyCarLoanComponent,
        ApplyEduLoanComponent,
        ApplyHomeLoanComponent,
  ],

  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ApplyLoanRoutingModule,
   
  ],

  exports: [
    ApplyLoanRoutingModule,
      ApplyCarLoanComponent,
      ApplyEduLoanComponent,
      ApplyHomeLoanComponent,
  ]
})
export class ApplyLoanModule {

}
