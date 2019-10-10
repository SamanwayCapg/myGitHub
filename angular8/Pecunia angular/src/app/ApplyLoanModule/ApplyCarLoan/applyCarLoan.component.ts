import { Component, OnInit } from '@angular/core';
import { CarLoan } from '../../Models/carLoans';
import { CarLoanServices } from '../../Services/carLoans.services';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { PecuniaComponentBase } from '../../pecunia-component';
import * as $ from "jquery";

import { Router } from '@angular/router';


@Component({
  selector: 'apply-Car-Loan',
  templateUrl: './applyCarLoan.component.html',
  styleUrls: ['./applyCarLoan.component.scss']
})


export class ApplyCarLoanComponent extends PecuniaComponentBase
{

  title = 'Loan Management System';

  newCarLoan: CarLoan;
  showLoadingSpinner: boolean = false;

  newApplyForm: FormGroup;
  //newApplyFormErrMsg: any;

  constructor(private carLoanService : CarLoanServices) {
    super();
    this.newApplyForm = new FormGroup({
      customerID: new FormControl(null, [Validators.required]), 
      amountApplied: new FormControl(null, [Validators.required]),
      repaymentPeriod: new FormControl(null, [Validators.required]),
      occupation: new FormControl(null, [Validators.required]),
      grossIncome: new FormControl(null, [Validators.required]),
      salaryDeductions: new FormControl(null, [Validators.required]),
      vehicle: new FormControl(null, [Validators.required]),

    });

  }

  onApplyCarLoanClick(event) {
    this.newApplyForm["submitted"] = true;
    
    if (this.newApplyForm.valid) {
      var newCarLoan: CarLoan;// = this.newApplyForm.value;
      newCarLoan = new CarLoan(); //alert(55);
      newCarLoan.customerID = this.newApplyForm.value.customerID;
      newCarLoan.amountApplied = this.newApplyForm.value.amountApplied;
      newCarLoan.reapaymentPeriod = this.newApplyForm.value.repaymentPeriod;
      newCarLoan.occupation = this.newApplyForm.value.occupation;
      newCarLoan.grossIncome = this.newApplyForm.value.grossIncome;
      newCarLoan.salaryDeductions = this.newApplyForm.value.salaryDeductions;
      newCarLoan.vehicle = this.newApplyForm.value.vehicle;

      /*newCarLoan.loanID = "123456789";
      newCarLoan.EMI_amount = (newCarLoan.amountApplied * (1 + (10.65 / 100))) / newCarLoan.reapaymentPeriod
      newCarLoan.dateOfApplication = "12/12/2012";
      newCarLoan.status = "APPLIED";
      */
      console.log(this.newApplyForm.value);
      this.carLoanService.ApplyCarLoan(newCarLoan).subscribe((addResponse) => {
        this.newApplyForm.reset();
        this.showLoadingSpinner = true;
      }, (error) => {
        console.log(error);
      });
    }
    else {
      super.getFormGroupErrors(this.newApplyForm);
    }
  }
  

}
