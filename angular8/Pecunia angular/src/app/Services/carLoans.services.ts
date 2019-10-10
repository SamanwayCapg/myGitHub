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

    ApplyCarLoan(newCarLoan: CarLoan): Observable<boolean>{
        newCarLoan.loanID = this.uuidv4();
        newCarLoan.interestRate = 10.65;
        newCarLoan.EMI_amount = (newCarLoan.amountApplied * (1 + (10.65 / 100))) / newCarLoan.reapaymentPeriod;
        newCarLoan.dateOfApplication = new Date.ToLocaleDateString();
        newCarLoan.status = "APPLIED";

        return this.httpClient.post<boolean>(`/api/carLoans`, newCarLoan);
    }

    ApproveCarLoan(existingCarLoan: CarLoan, newStatus: string): Observable<boolean> {
        existingCarLoan.status = newStatus;
        return this.httpClient.put<boolean>(`api/carLoans`, existingCarLoan);
    }

    GetCarLoanByCustomerID(customerID: string): Observable<CarLoan> {
        return this.httpClient.get<CarLoan>(`/api/carLoans?customerID=${customerID}`);
    }

    GetCarLoanByLoanID(loanID: string): Observable<CarLoan> {
        return this.httpClient.get<CarLoan>(`api/carLoans ? loanID=${loanID}`);
    }

    GetCarLoanStatus(loanID: string): Observable<string> {
        return this.httpClient.get<string>(`api/carLoans/status ? loanID=${loanID}`);
    }

    uuidv4() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}
