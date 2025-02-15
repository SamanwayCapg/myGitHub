import { Component, OnInit } from '@angular/core';

import { FormControl, Validators, FormGroup } from '@angular/forms';
import { PecuniaComponentBase } from 'src/app/pecunia-component';
import { CarLoanServices } from 'src/app/Services/carLoans.services';
import { CustomersService } from 'src/app/Services/customers.service';
import { CarLoan } from 'src/app/Models/carLoans';
import { Customer } from 'src/app/Models/customer';




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

    alreadyHaveCarLoan: boolean = false;

  constructor(private carLoanService: CarLoanServices, private customerService: CustomersService)
  {
    super();
    this.newApplyForm = new FormGroup({
        //user inputs
        amountApplied: new FormControl(null, [Validators.required, Validators.max(2000000), Validators.min(100000)]),
        reapaymentPeriod: new FormControl(null, [Validators.required, Validators.max(120), Validators.min(2)]),
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
            reapaymentPeriod: { required: "This field can't be blank", max: "Maximum repayment period is 120 months", min: "Minimum repayment period is 2 months" },
            grossIncome: { required: "This field can't be blank", min: "Your income figure must a positive amount" },
            salaryDeductions: { required: "This field can't be blank", min: "Your deduction figure must a positive amount"}
        };

  }

    test() {
        console.log("test");
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
        this.showLoadingSpinner = true;
        //checking if customer already have a car laon
      this.carLoanService.GetCarLoanByCustomerID(this.customers[index].customerID).subscribe((response) => {
        console.log(response);
        if (response.length == 1) {//the error showing in vs is false its working
                this.alreadyHaveCarLoan = true;
                this.carloans = response;
                //this.carloan.amountApplied = response.amountApplied;
                //this.carloan.dateOfApplication = response.dateOfApplication;
                //this.carloan.EMI_amount = response.EMI_amount;
            }
            else
                this.alreadyHaveCarLoan = false;

            this.showLoadingSpinner = false;
        },
        (error) => {
            console.log(error);
        });

        this.newApplyForm.reset();
        this.newApplyForm["submitted"] = false;
        this.newApplyForm.patchValue({
            customerID: this.customers[index].customerID
        });
    }

  // applying for a new car loan
  onApplyClick(event) {
      this.newApplyForm["submitted"] = true;
      var alreadyHaveCarLoan: boolean = false;

      //checking if customer already have a car laon
      this.carLoanService.GetCarLoanByCustomerID(this.newApplyForm.value.customerID).subscribe((response) => {
          console.log("already have a laon");
      },
      (error) => {
              console.log("dont have a laon");
      });
      
      if (this.newApplyForm.valid) {
          var newCarLoan = this.newApplyForm.value;

          //setting up system generated and computed values
          //this.newApplyForm.patchValue({
          //    loanID: this.uuidv4(),
          //    interestRate: 10.65,
          //    EMI_amount: (this.newApplyForm.value.amountApplied * (1 + (10.65 / 100))) / this.newApplyForm.value.repaymentPeriod,
          //    dateOfApplication:new Date().toLocaleDateString(),
          //    status: "APPLIED",
          //    customerID: this.newApplyForm.value.customerID
          //});

      
            console.log(this.newApplyForm.value);
            this.carLoanService.ApplyCarLoan(newCarLoan).subscribe((addResponse) => {
            this.newApplyForm.reset();
            this.showLoadingSpinner = false;
                
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

    getFormGroupStatus(formGroupName: FormGroup) {
        return formGroupName.valid;
    }

    uuidv4() {
      return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
          var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
          return v.toString(16);
      });
  }
}
