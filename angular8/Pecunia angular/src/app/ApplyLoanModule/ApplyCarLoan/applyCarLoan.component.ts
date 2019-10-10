import { Component, OnInit } from '@angular/core';
import { CarLoanServices } from '../../Services/carLoans.services';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { PecuniaComponentBase } from '../../pecunia-component';
import * as $ from "jquery";
import { CarLoan } from '../../Models/carLoans';
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
      //var newCarLoan: CarLoan;// = this.newApplyForm.value;
        //alert(55);
        var customerID: string = this.newApplyForm.value.customerID;
        var amountApplied: number = this.newApplyForm.value.amountApplied;
        var repaymentPeriod: number = this.newApplyForm.value.repaymentPeriod;
        var occupation: string = this.newApplyForm.value.occupation;
        var grossIncome: number = this.newApplyForm.value.grossIncome;
        var salaryDeductions: number = this.newApplyForm.value.salaryDeductions;
        var vehicle: string = this.newApplyForm.value.vehicle;

        var loanID: string = this.uuidv4();
        var interestRate: number = 10.65;
        var EMI_amount: number = (amountApplied * (1 + (10.65 / 100))) / repaymentPeriod;
        var dateOfApplication: string = new Date().toLocaleDateString();
        var status: string = "APPLIED";
      
        var newCarLoan: CarLoan = new CarLoan(1,
            loanID,
            customerID,
            amountApplied,
            interestRate,
            EMI_amount,
            repaymentPeriod,
            dateOfApplication,
            status,
            occupation,
            grossIncome,
            salaryDeductions,
          vehicle
          );

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
  

  uuidv4() {
      return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
          var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
          return v.toString(16);
      });
  }
}
