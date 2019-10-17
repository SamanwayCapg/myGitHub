import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'apply-loan',
  templateUrl: './applyLoan.component.html',
  styleUrls: ['./applyLoan.component.scss']
})
export class ApplyLoanComponent {

  constructor(private router: Router)
  {

  }

  onLoanTypeClick()
  {
    this.router.navigate(["/applyLoanModule", "applyCarLoan"]);

  }

}
