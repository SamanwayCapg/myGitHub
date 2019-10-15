import { Component, OnInit } from '@angular/core';
import { HomeLoanServices } from '../../Services/homeLoans.services';
import { CustomerServices } from '../../Services/cutomers.services';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { PecuniaComponentBase } from '../../pecunia-component';
import { HomeLoan } from '../../Models/homeLoans';
import { Customer } from '../../Models/customers';


@Component({
  selector: 'apply-Home-Loan',
  templateUrl: './applyHomeLoan.component.html',
  styleUrls: ['./applyHomeLoan.component.scss']
})


export class ApplyHomeLoanComponent extends PecuniaComponentBase implements OnInit
{

    title = 'Loan Management System';

    newHomeLoan: HomeLoan;
    showLoadingSpinner: boolean = false;
    
    newApplyForm: FormGroup;
    newApplyFormErrorMessages: any;

    customers: Customer[] = [];
    homeloans: HomeLoan[] = [];
    homeloan: HomeLoan;

    alreadyHaveHomeLoan: boolean = false;

  constructor(private homeLoanService: HomeLoanServices, private customerService: CustomerServices)
  {
    super();
    this.newApplyForm = new FormGroup({
        //user inputs
        amountApplied: new FormControl(null, [Validators.required, Validators.max(2000000), Validators.min(100000)]),
        reapaymentPeriod: new FormControl(null, [Validators.required, Validators.max(180), Validators.min(2)]),
        occupation: new FormControl(null, [Validators.required]),
        grossIncome: new FormControl(null, [Validators.required, Validators.min(1)]),
        salaryDeductions: new FormControl(null, [Validators.required, Validators.min(1)]),
        serviceYears: new FormControl(null, [Validators.required, Validators.min(5)]),


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
            reapaymentPeriod: { required: "This field can't be blank", max: "Maximum repayment period is 180 months", min: "Minimum repayment period is 2 months" },
            grossIncome: { required: "This field can't be blank", min: "Your income figure must a positive amount" },
            salaryDeductions: { required: "This field can't be blank", min: "Your deduction figure must a positive amount" },
            serviceYears: { required: "This field can't be blank", min: "You need a minimum of 5 year work experience" }
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
        this.showLoadingSpinner = true;
        //checking if customer already have a home laon
      this.homeLoanService.GetHomeLoanByCustomerID(this.customers[index].customerID).subscribe((response) => {
        console.log(response);
        if (response.length == 1) {//the error showing in vs is false its working
                this.alreadyHaveHomeLoan = true;
                this.homeloans = response;
                //this.homeloan.amountApplied = response.amountApplied;
                //this.homeloan.dateOfApplication = response.dateOfApplication;
                //this.homeloan.EMI_amount = response.EMI_amount;
            }
            else
                this.alreadyHaveHomeLoan = false;

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

  // applying for a new home loan
  onApplyClick(event) {
      this.newApplyForm["submitted"] = true;
      var alreadyHaveHomeLoan: boolean = false;

      //checking if customer already have a home laon
      this.homeLoanService.GetHomeLoanByCustomerID(this.newApplyForm.value.customerID).subscribe((response) => {
          console.log("already have a laon");
      },
      (error) => {
              console.log("dont have a laon");
      });
      
      if (this.newApplyForm.valid) {
          var newHomeLoan = this.newApplyForm.value;

          console.log(this.newApplyForm.value);
            this.homeLoanService.ApplyHomeLoan(newHomeLoan).subscribe((addResponse) => {
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

    getFormControlStatus(formControlName: string, validationProperty: string, formGroupName: FormGroup): boolean {
        return (formGroupName.get(formControlName).touched &&
                formGroupName.get(formControlName).invalid &&
                formGroupName.get(formControlName).errors[validationProperty]);
            
    }

    getFormGroupStatus(formGroupName: FormGroup) {
        return formGroupName.valid;
    }

  }
}
