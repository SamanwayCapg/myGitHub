import { Component, OnInit } from '@angular/core';
import { CarLoanServices } from '../../Services/carLoans.services';
import { CustomerServices } from '../../Services/cutomers.services';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { PecuniaComponentBase } from '../../pecunia-component';
import * as $ from "jquery";
import { CarLoan } from '../../Models/carLoans';
import { Customer } from '../../Models/customers';
import { Router } from '@angular/router';


@Component({
  selector: 'apply-Car-Loan',
  templateUrl: './applyCarLoan.component.html',
  styleUrls: ['./applyCarLoan.component.scss']
})


export class ApplyCarLoanComponent extends PecuniaComponentBase implements OnInit
{

    title = 'Loan Management System';

    newCarLoan: CarLoan;
    showLoadingSpinner: boolean = false;

    newApplyForm: FormGroup;
    newApplyFormErrorMessages: any;

    customers: Customer[] = [];
    carloans: CarLoan[] = [];
    carloan: CarLoan;

    constructor(private carLoanService: CarLoanServices, private customerService: CustomerServices) {
    super();
    this.newApplyForm = new FormGroup({
        //user inputs
        amountApplied: new FormControl(null, [Validators.required]),
        repaymentPeriod: new FormControl(null, [Validators.required]),
        occupation: new FormControl(null, [Validators.required]),
        grossIncome: new FormControl(null, [Validators.required]),
        salaryDeductions: new FormControl(null, [Validators.required]),
        vehicle: new FormControl(null, [Validators.required]),

        //system generated or computed internally
        customerID: new FormControl(null),
        id: new FormControl(null),
        loanID: new FormControl(null),
        interestRate: new FormControl(null),
        EMI_amount: new FormControl(null),
        dateOfApplication: new FormControl(null),
        status: new FormControl(null),

    });

        this.newApplyFormErrorMessages = {
            amountApplied: { required: "Amount can't be blank"}
        };

  }

    ngOnInit() {
        this.showLoadingSpinner = true;
        this.customerService.GetAllCustomers().subscribe((response) => {
            this.customers = response;
            this.showLoadingSpinner = false;
            console.log(response);
        }, (error) => {
            console.log(error);
        })
    }


  // applying for a new car loan
  onApplyNowClick(index) {
    this.newApplyForm["submitted"] = true;
    
      if (this.newApplyForm.valid) {
          var newCarLoan = this.newApplyForm.value;

          //setting up system generated and computed values
          this.newApplyForm.patchValue({
              loanID: this.uuidv4(),
              interestRate: 10.65,
              EMI_amount: (this.newApplyForm.value.amountApplied * (1 + (10.65 / 100))) / this.newApplyForm.value.repaymentPeriod,
              dateOfApplication:new Date().toLocaleDateString(),
              status: "APPLIED"

          });

      
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
  
    getFormControlCssClass(formControl: FormControl, formGroup: FormGroup): any {
        return {
            'is-invalid': formControl.invalid && (formControl.dirty || formControl.touched || formGroup["submitted"]),
            'is-valid': formControl.valid && (formControl.dirty || formControl.touched || formGroup["submitted"])
        };
    }

    getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
        return this.newApplyFormErrorMessages[formControlName][validationProperty];
    }

    getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean {
        return formGroup.get(formControlName).invalid && (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) && formGroup.get(formControlName).errors[validationProperty];
    }

  uuidv4() {
      return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
          var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
          return v.toString(16);
      });
  }
}
