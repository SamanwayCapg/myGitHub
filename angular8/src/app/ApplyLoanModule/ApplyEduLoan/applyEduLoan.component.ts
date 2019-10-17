import { Component, OnInit } from '@angular/core';
import { EduLoanServices } from '../../Services/eduLoans.services';
import { CustomerServices } from '../../Services/cutomers.services';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { PecuniaComponentBase } from '../../pecunia-component';
import { EduLoan } from '../../Models/eduLoans';
import { Customer } from '../../Models/customers';


@Component({
  selector: 'apply-Edu-Loan',
  templateUrl: './applyEduLoan.component.html',
  styleUrls: ['./applyEduLoan.component.scss']
})


export class ApplyEduLoanComponent extends PecuniaComponentBase implements OnInit
{

    title = 'Loan Management System';

    newEduLoan: EduLoan;
    showLoadingSpinner: boolean = false;
    
    newApplyForm: FormGroup;
    newApplyFormErrorMessages: any;

    customers: Customer[] = [];
    eduloans: EduLoan[] = [];
    eduloan: EduLoan;

    alreadyHaveEduLoan: boolean = false;

  constructor(private eduLoanService: EduLoanServices, private customerService: CustomerServices)
  {
    super();
    this.newApplyForm = new FormGroup({
        //user inputs
        amountApplied: new FormControl(null, [Validators.required, Validators.max(2000000), Validators.min(10000)]),
        reapaymentPeriod: new FormControl(null, [Validators.required, Validators.max(96), Validators.min(2)]),
        course: new FormControl(null, [Validators.required]),
        instituteName: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
        studentID: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
        
        //system generated or computed internally
        customerID: new FormControl(null),
        id: new FormControl(null),
        loanID: new FormControl(null),
        interestRate: new FormControl(null),
        EMI_amount: new FormControl(null),
        dateOfApplication: new FormControl(null),
        status: new FormControl(null),
        repaymentHoliday: new FormControl(null),
    });

        this.newApplyFormErrorMessages = {
            amountApplied: { required: "This field can't be blank", max:"Maximum allowed amount is Rs.20 lakhs", min:"Amount must be atleast Rs.10000" },
            reapaymentPeriod: { required: "This field can't be blank", max: "Maximum repayment period is 96 months", min: "Minimum repayment period is 2 months" },
            course: { required: "This field can't be blank" },
            instituteName: { required: "This field can't be blank", maxLength: "Institute Name can contain maximum 100 characters" },
            studentID: { required: "This field can't be blank", maxLength: "Student ID can contain maximum 20 characters" }
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
        //checking if customer already have a edu laon
      this.eduLoanService.GetEduLoanByCustomerID(this.customers[index].customerID).subscribe((response) => {
        console.log(response);
        if (response.length == 1) {//the error showing in vs is false its working
                this.alreadyHaveEduLoan = true;
                this.eduloans = response;
                //this.eduloan.amountApplied = response.amountApplied;
                //this.eduloan.dateOfApplication = response.dateOfApplication;
                //this.eduloan.EMI_amount = response.EMI_amount;
            }
            else
                this.alreadyHaveEduLoan = false;

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

  // applying for a new edu loan
  onApplyClick(event) {
      this.newApplyForm["submitted"] = true;
      var alreadyHaveEduLoan: boolean = false;

      //checking if customer already have a edu laon
      this.eduLoanService.GetEduLoanByCustomerID(this.newApplyForm.value.customerID).subscribe((response) => {
          console.log("already have a laon");
      },
      (error) => {
              console.log("dont have a laon");
      });
      
      if (this.newApplyForm.valid) {
          var newEduLoan = this.newApplyForm.value;

            console.log(this.newApplyForm.value);
            this.eduLoanService.ApplyEduLoan(newEduLoan).subscribe((addResponse) => {
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
