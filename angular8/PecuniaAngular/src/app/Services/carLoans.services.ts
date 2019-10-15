import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarLoan } from '../Models/carLoans';

@Injectable({
    providedIn:'root'
})
export class CarLoanServices {
    constructor(private httpClient: HttpClient) {

    }

  ApplyCarLoan(newCarLoan: CarLoan): Observable<boolean> {
      //alert(newCarLoan.loanID);
      //newCarLoan.id = 1;
      newCarLoan.loanID = this.uuidv4();
      newCarLoan.interestRate = 10.65;
      newCarLoan.EMI_amount = (newCarLoan.amountApplied * (1 + (10.65 / 100))) / newCarLoan.reapaymentPeriod;
      console.log("EMI:" + newCarLoan.EMI_amount);
      newCarLoan.dateOfApplication = new Date().toLocaleDateString();
      newCarLoan.status = "APPLIED";
      console.log(newCarLoan);
      return this.httpClient.post<boolean>(`/api/carloans`, newCarLoan);
    }

    ApproveCarLoan(existingCarLoan: CarLoan, newStatus: string): Observable<boolean> {
        existingCarLoan.status = newStatus;
        return this.httpClient.put<boolean>(`/api/carloans`, existingCarLoan);
    }

    GetCarLoanByCustomerID(customerID: string): Observable<CarLoan[]> {
        return this.httpClient.get<CarLoan[]>(`/api/carloans?customerID=${customerID}`);
    }

    GetCarLoanByLoanID(loanID: string): Observable<CarLoan[]> {
        return this.httpClient.get<CarLoan[]>(`/api/carloans?loanID=${loanID}`);
    }

    ///dont use the function
    GetCarLoanStatus(loanID: string): Observable<string> {
        return this.httpClient.get<string>(`/api/carloans/status?loanID=${loanID}`);
    }

    GetAllCarLoans(): Observable<CarLoan[]> {
        return this.httpClient.get<CarLoan[]>(`/api/carloans`);
    }
    uuidv4() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}
