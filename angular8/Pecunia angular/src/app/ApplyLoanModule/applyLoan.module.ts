import { NgModule } from '@angular/core';
import { ApplyCarLoanComponent } from './ApplyCarLoan/applyCarLoan.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplyLoanRoutingModule } from '../ApplyLoanModule/applyLoan-routing.module';


@NgModule({
  declarations: [
    ApplyCarLoanComponent
  ],

  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ApplyLoanRoutingModule,
   
  ],

  exports: [
    ApplyLoanRoutingModule,
    ApplyCarLoanComponent

  ]
})
export class ApplyLoanModule {

}
