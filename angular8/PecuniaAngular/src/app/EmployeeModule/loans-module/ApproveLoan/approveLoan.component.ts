import { Component, NgModule, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CarLoan } from 'src/app/Models/carLoans';
import { HomeLoan } from 'src/app/Models/homeLoans';
import { EduLoan } from 'src/app/Models/eduLoans';
import { EduLoanServices } from 'src/app/Services/eduLoans.services';
import { CarLoanServices } from 'src/app/Services/carLoans.services';
import { HomeLoanServices } from 'src/app/Services/homeLoans.services';

@Component({
  selector: 'approve-loan',
  templateUrl: './approveLoan.component.html',
  styleUrls: ['./approveLoan.component.scss']
})
export class ApproveLoanComponent implements OnInit {

    searchBoxForm: FormGroup;
    updateStatusForm: FormGroup;

    searchBoxErrorMsg: any;
    updatedStatusErrorMsg: any;
    updatedStatus: string;
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

      this.updateStatusForm = new FormGroup({
          updatedStatus: new FormControl(null, Validators.required)
      })

      this.updatedStatusErrorMsg = {
          updatedStatus: {required:"Status must be updated"}
      }
  }

  ngOnInit() {
    this.showLoadingSpinner = true;
    this.carLoanService.GetAllCarLoans().subscribe((response) => {
      this.carLoansTableDisplay = response;
      this.showLoadingSpinner = false;
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

    getSearchBoxFormErrorMessage(formControlName: string, validationProperty: string): string {
        return this.searchBoxErrorMsg[formControlName][validationProperty];
    }

    getUpdateStatusFormErrorMessage(formControlName: string, validationProperty: string): string {
        return this.updateStatusForm[formControlName][validationProperty];
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
      this.updateStatusForm.reset();
      this.IDselected = false;
      this.isCarLoan = false;
      this.isEduLoan = false;
      this.isHomeLoan = false;
  }

    onClickUpdateStatus() {
        this.showLoadingSpinner = true;
      this.updatedStatus = this.updateStatusForm.value.updatedStatus;
      console.log("status from html:" + this.updatedStatus);
        if (this.isCarLoan == true) {
            this.carLoanService.ApproveCarLoan(this.carLoans[0], this.updatedStatus).subscribe((response) => {
                this.showLoadingSpinner = false;
                console.log("status updation:" + response);
            }, (error) => {
                    console.log(error);
            })
        } else if (this.isEduLoan == true) {
            this.eduLoanService.ApproveEduLoan(this.eduLoans[0], this.updatedStatus).subscribe((response) => {
                this.showLoadingSpinner = false;
                console.log("status updation:" + response);
            }, (error) => {
                console.log(error);
            })
        } else {//this is home loan
            this.homeLoanService.ApproveHomeLoan(this.homeLoans[0], this.updatedStatus).subscribe((response) => {
                this.showLoadingSpinner = false;
                console.log("status updation:" + response);
            }, (error) => {
                console.log(error);
            })
      }
      this.ngOnInit();
    }

    
    showLoanInModal(value: number, loanID: string) {
        this.isCarLoan = false;
        this.isEduLoan = false;
        this.isHomeLoan = false;
        console.log(loanID);
        console.log(value);
        if (value == 3) {
            this.isCarLoan = true;
            this.carLoanService.GetCarLoanByLoanID(loanID).subscribe((response) => {
                this.carLoans = response;
                console.log(this.carLoans[0]);
            },
                (error) => {
                    console.log(error);
                })
        }
        else if (value == 2) {
            this.isEduLoan = true;
            this.eduLoanService.GetEduLoanByLoanID(loanID).subscribe((response) => {
                this.eduLoans = response;
                console.log(this.eduLoans[0]);
            },
                (error) => {
                    console.log(error);
                })
        }
        else {
            this.isHomeLoan = true;
            this.homeLoanService.GetHomeLoanByLoanID(loanID).subscribe((response) => {
                this.homeLoans = response;
                console.log(this.homeLoans[0]);
            },
                (error) => {
                    console.log(error);
                })
        }
    }
}

