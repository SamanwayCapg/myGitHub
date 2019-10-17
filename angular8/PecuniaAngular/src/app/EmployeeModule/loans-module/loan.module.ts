import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { LoanRoutingModule } from './loan-routing.module';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplyCarLoanComponent } from './ApplyCarLoan/applyCarLoan.component';
import { ApplyEduLoanComponent } from './ApplyEduLoan/applyEduLoan.component';
import { ApplyHomeLoanComponent } from './ApplyHomeLoan/applyHomeLoan.component';
import { ShowLoanComponent } from './ShowLoan/showLoan.component';
import { ApproveLoanComponent } from './ApproveLoan/approveLoan.component';
import { PecuniaDataService } from 'src/app/InMemoryWebAPIServices/employees-data.service';
import { LoanComponent } from './Loan/loan.component';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    LoanComponent,
    ApplyCarLoanComponent,
    ApplyEduLoanComponent,
    ApplyHomeLoanComponent,
    ShowLoanComponent,
    ApproveLoanComponent
  ],

  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    LoanRoutingModule,
  ],

  exports: [
    LoanComponent,
    ApplyCarLoanComponent,
    ApplyEduLoanComponent,
    ApplyHomeLoanComponent,
    ShowLoanComponent,
    ApproveLoanComponent,
    LoanRoutingModule
  ]
})
export class LoanModule {

}
