import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { EduLoan } from '../Models/eduLoans'

@Injectable({
  providedIn: 'root'
})
export class EduLoanService
{
  constructor(private httpClient: HttpClient)
  {

  }

}
