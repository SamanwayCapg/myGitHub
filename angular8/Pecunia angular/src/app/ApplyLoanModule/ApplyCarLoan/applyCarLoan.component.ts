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
        amountApplied: new FormControl(null, [Validators.required, Validators.max(2000000), Validators.min(100000)]),
        repaymentPeriod: new FormControl(null, [Validators.required, Validators.max(120), Validators.min(2)]),
        occupation: new FormControl(null, [Validators.required]),
        grossIncome: new FormControl(null, [Validators.required, Validators.min(1)]),
        salaryDeductions: new FormControl(null, [Validators.required, Validators.min(1)]),
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
            amountApplied: { required: "This field can't be blank", max:"Maximum allowed amount is Rs.20 lakhs", min:"Amount must be atleast Rs.1 lakh" },
            repaymentPeriod: { required: "This field can't be blank", max: "Maximum repayment period is 120 months", min: "Minimum repayment period is 2 months" },
            grossIncome: { required: "This field can't be blank", min: "Your income figure must a positive amount" },
            salaryDeductions: { required: "This field can't be blank", min: "Your deduction figure must a positive amount"}
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


    onApplyHereClick(index) {
        this.newApplyForm.reset();
        this.newApplyForm["submitted"] = false;
        this.newApplyForm.patchValue({
            customerID: this.customers[index].customerID
        });
    }

  // applying for a new car loan
  onApplyClick(event) {
      this.newApplyForm["submitted"] = true;
      
      if (this.newApplyForm.valid) {
          var newCarLoan = this.newApplyForm.value;

          //setting up system generated and computed values
          this.newApplyForm.patchValue({
              loanID: this.uuidv4(),
              interestRate: 10.65,
              EMI_amount: (this.newApplyForm.value.amountApplied * (1 + (10.65 / 100))) / this.newApplyForm.value.repaymentPeriod,
              dateOfApplication:new Date().toLocaleDateString(),
              status: "APPLIED",
              customerID: this.newApplyForm.value.customerID
          });

      
        console.log(this.newApplyForm.value);
        this.carLoanService.ApplyCarLoan(newCarLoan).subscribe((addResponse) => {
        this.newApplyForm.reset();
        this.showLoadingSpinner = true;

            console.log(newCarLoan);
      }, (error) => {
        console.log(error);
      });
    }
    else {
      super.getFormGroupErrors(this.newApplyForm);
    }
  }

    onCancelClick() {
        this.newApplyForm.reset();
    }
  
    getFormControlCSSInfo(formGroupName: FormGroup, formControlName: FormControl) {
        //return formControlName.touched && formControlName.invalid;
        return {
            'is-invalid': formControlName.invalid && (formControlName.dirty || formControlName.touched || formGroupName["submitted"]),
            'is-valid': formControlName.valid && (formControlName.dirty || formControlName.touched || formGroupName["submitted"])
        }
    }

    getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
        return this.newApplyFormErrorMessages[formControlName][validationProperty];
    }

    //getCanShowFormControlErrorMessage(formControlName: string, validationProperty: string, formGroup: FormGroup): boolean {
    //    return formGroup.get(formControlName).invalid &&
    //           (formGroup.get(formControlName).dirty || formGroup.get(formControlName).touched || formGroup['submitted']) &&
    //           formGroup.get(formControlName).errors[validationProperty];
    //}

    getFormControlStatus(formControlName: string, validationProperty: string, formGroupName: FormGroup): boolean {
        return (formGroupName.get(formControlName).touched &&
                formGroupName.get(formControlName).invalid &&
                formGroupName.get(formControlName).errors[validationProperty]);
            
    }

  uuidv4() {
      return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
          var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
          return v.toString(16);
      });
  }
}
