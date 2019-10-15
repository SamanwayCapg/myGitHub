import { Component, NgModule, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CarLoanServices } from '../../Services/carLoans.services';
import { HomeLoanServices } from '../../Services/homeLoans.services';
import { EduLoanServices } from '../../Services/eduLoans.services';
import { CarLoan } from '../../Models/carLoans';
import { HomeLoan } from '../../Models/homeLoans';
import { EduLoan } from '../../Models/eduLoans';

@Component({
  selector: 'approve-loan',
  templateUrl: './approveLoan.component.html',
  styleUrls: ['./approveLoan.component.scss']
})
export class ApproveLoanComponent implements OnInit {

    searchBoxForm: FormGroup;
  searchBoxErrorMsg: any;
  carLoans: CarLoan[] =[];
  homeLoans: HomeLoan[] =[];
  eduLoans: EduLoan[] = [];

  carLoansTableDisplay: CarLoan[] = [];
  homeLoansTableDisplay: HomeLoan[] = [];
  eduLoansTableDisplay: EduLoan[] = [];

    IDselected: boolean = false;
  IDtype: number = 0;
  showLoadingSpinner: boolean = false;
  isValidID: boolean;
  isCarLoan: boolean = false;
  isHomeLoan: boolean = false;
  isEduLoan: boolean = false;

  constructor(private carLoanService: CarLoanServices, private eduLoanService: EduLoanServices, private homeLoanService: HomeLoanServices) {
        console.log("constructor");

        this.searchBoxForm = new FormGroup({
            selectID: new FormControl(null),
            inputID: new FormControl(null, [Validators.minLength(36),  Validators.required])
        })

        this.searchBoxErrorMsg = {
            inputID: { minLength:"ID length 36",   required:"ID is required"}
        };
  }

  ngOnInit() {
    this.carLoanService.GetAllCarLoans().subscribe((response) => {
      this.carLoansTableDisplay = response;
      console.log(this.carLoans);
    }, (error) => {
      console.log(error);
      })

    this.eduLoanService.GetAllEduLoans().subscribe((response) => {
      this.eduLoansTableDisplay = response;
    }, (error) => {
      console.log(error);
      })

    this.homeLoanService.GetAllHomeLoans().subscribe((response) => {
      this.homeLoansTableDisplay = response;
    }, (error) => {
      console.log(error);
      })
  }

    getFormControlStatus(formControlName: string, validationProperty: string, formGroupName: FormGroup): boolean {
        return (formGroupName.get(formControlName).touched &&
            formGroupName.get(formControlName).invalid &&
            formGroupName.get(formControlName).errors[validationProperty]);

    }

    getFormGroupStatus(formGroupName: FormGroup) {
        return formGroupName.valid;
    }

    getFormControlErrorMessage(formControlName: string, validationProperty: string): string {
        return this.searchBoxErrorMsg[formControlName][validationProperty];
    }

  

  public onChangeSearchBy(event): void {
   
    this.IDtype = event.target.value;
    this.IDselected = true;
    console.log("here:" + this.IDtype);
    
  }

  public getLoanDetails() {
    this.isCarLoan = false;
    this.isEduLoan = false;
    this.isHomeLoan = false;

    var ID: string = this.searchBoxForm.value.inputID;
    console.log("ID entered:" + ID);
    this.showLoadingSpinner = true;

    //serach by customerId selected
    if (this.IDtype == 1) {
      this.carLoanService.GetCarLoanByCustomerID(ID).subscribe((carLoanResponse) => {
        if (carLoanResponse.length > 0) {
          this.showLoadingSpinner = false;
          this.isCarLoan = true;
          this.carLoans = carLoanResponse;
          console.log(carLoanResponse[0]);
        } else {//ID is not of carLoan
          this.homeLoanService.GetHomeLoanByCustomerID(ID).subscribe((homeLoanResponse) => {
            if (homeLoanResponse.length > 0) {
              this.showLoadingSpinner = false;
              this.isHomeLoan = true;
              this.homeLoans = homeLoanResponse;
              console.log(homeLoanResponse[0]);
            } else {//ID is not of carloan or homeloan
              this.eduLoanService.GetEduLoanByCustomerID(ID).subscribe((eduLoanResponse) => {
                if (eduLoanResponse.length > 0) {
                  this.showLoadingSpinner = false;
                  this.isEduLoan = true;
                  this.eduLoans = eduLoanResponse;
                  console.log(eduLoanResponse[0]);
                } else {//not a valid loanID
                  this.showLoadingSpinner = false;
                  this.isValidID = false;
                  console.log("invalid id");
                }
              },
                (error) => {
                  this.showLoadingSpinner = false;
                  console.log(error);
                })
            }
          },
            (error) => {
              this.showLoadingSpinner = false;
              console.log(error);
            })
        }
      },
        (error) => {
          this.showLoadingSpinner = false;
          console.log(error);
        })
    }
    else //search by loanID is selected
    {
      this.carLoanService.GetCarLoanByLoanID(ID).subscribe((carLoanResponse) => {
        if (carLoanResponse.length > 0) {
          this.showLoadingSpinner = false;
          this.isCarLoan = true;
          this.carLoans = carLoanResponse;
          console.log(carLoanResponse[0]);
        } else {//ID is not of carLoan
          this.homeLoanService.GetHomeLoanByLoanID(ID).subscribe((homeLoanResponse) => {
            if (homeLoanResponse.length > 0) {
              this.showLoadingSpinner = false;
              this.isHomeLoan = true;
              this.homeLoans = homeLoanResponse;
              console.log(homeLoanResponse[0]);
            } else {//ID is not of carloan or homeloan
              this.eduLoanService.GetEduLoanByLoanID(ID).subscribe((eduLoanResponse) => {
                if (eduLoanResponse.length > 0) {
                  this.showLoadingSpinner = false;
                  this.isEduLoan = true;
                  this.eduLoans = eduLoanResponse;
                  console.log(eduLoanResponse[0]);
                } else {//not a valid loanID
                  this.showLoadingSpinner = false;
                  this.isValidID = false;
                  console.log("invalid id");
                }
              },
                (error) => {
                  this.showLoadingSpinner = false;
                  console.log(error);
                })
            }
          },
            (error) => {
              this.showLoadingSpinner = false;
              console.log(error);
            })
        }
      },
        (error) =>
        {
          this.showLoadingSpinner = false;
          console.log(error);
      })
    }
    
  }

  public resetshowLoanDetailsModal() {
    this.searchBoxForm.reset();
    this.IDselected = false;
  }
}

