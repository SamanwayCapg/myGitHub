import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EduLoan } from '../Models/eduLoans';

@Injectable({
  providedIn: 'root'
})
export class EduLoanServices {
  constructor(private httpClient: HttpClient) {

  }

  ApplyEduLoan(newEduLoan: EduLoan): Observable<boolean> {
    newEduLoan.loanID = this.uuidv4();
    newEduLoan.interestRate = 10.65;
    newEduLoan.EMI_amount = (newEduLoan.amountApplied * (1 + (10.65 / 100))) / newEduLoan.reapaymentPeriod;
    newEduLoan.dateOfApplication = new Date().toLocaleDateString();
    newEduLoan.status = "APPLIED";

    return this.httpClient.post<boolean>(`/api/eduLoans`, newEduLoan);
  }

  ApproveEduLoan(existingEduLoan: EduLoan, newStatus: string): Observable<boolean> {
    existingEduLoan.status = newStatus;
    return this.httpClient.put<boolean>(`api/eduLoans`, existingEduLoan);
  }

  GetEduLoanByCustomerID(customerID: string): Observable<EduLoan> {
    return this.httpClient.get<EduLoan>(`/api/eduLoans?customerID=${customerID}`);
  }

  GetEduLoanByLoanID(loanID: string): Observable<EduLoan> {
    return this.httpClient.get<EduLoan>(`api/eduLoans ? loanID=${loanID}`);
  }

  GetEduLoanStatus(loanID: string): Observable<string> {
    return this.httpClient.get<string>(`api/eduLoans/status ? loanID=${loanID}`);
  }

  uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}
