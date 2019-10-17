import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HomeLoan } from '../Models/homeLoans';

@Injectable({
  providedIn: 'root'
})
export class HomeLoanServices {
  constructor(private httpClient: HttpClient) {

  }

  ApplyHomeLoan(newHomeLoan: HomeLoan): Observable<boolean> {
    newHomeLoan.loanID = this.uuidv4();
    newHomeLoan.interestRate = 8.50;
    newHomeLoan.EMI_amount = (newHomeLoan.amountApplied * (1 + (8.50 / 100))) / newHomeLoan.reapaymentPeriod;
    newHomeLoan.dateOfApplication = new Date().toLocaleDateString();
    newHomeLoan.status = "APPLIED";

    return this.httpClient.post<boolean>(`/api/homeloans`, newHomeLoan);
  }

  ApproveHomeLoan(existingHomeLoan: HomeLoan, newStatus: string): Observable<boolean> {
    existingHomeLoan.status = newStatus;
    return this.httpClient.put<boolean>(`api/homeloans`, existingHomeLoan);
  }

  GetHomeLoanByCustomerID(customerID: string): Observable<HomeLoan[]> {
    return this.httpClient.get<HomeLoan[]>(`/api/homeloans?customerID=${customerID}`);
  }

  GetHomeLoanByLoanID(loanID: string): Observable<HomeLoan[]> {
    return this.httpClient.get<HomeLoan[]>(`api/homeloans?loanID=${loanID}`);
  }

  ///dont use the function
  GetHomeLoanStatus(loanID: string): Observable<string> {
    return this.httpClient.get<string>(`api/homeloans/status?loanID=${loanID}`);
  }

  GetAllHomeLoans(): Observable<HomeLoan[]> {
    return this.httpClient.get<HomeLoan[]>(`/api/homeloans`);
  }

  uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}
