export class HomeLoan {

  id: number;
  loanID: string;
  customerID: string;
  amountApplied: number;
  interestRate: number;
  EMI_amount: number;
  reapaymentPeriod: number;
  dateOfApplication: string;
  status: string;

  occupation: string;
  serviceYears: number;
  grossIncome: number;
  salaryDeductions: number;

  constructor(ID: number,
    LoanID: string,
    CustomerID: string,
    AmountApplied: number,
    InterestRate: number,
    EMI_Amount: number,
    RepaymentPeriod: number,
    DateOfApplication: string,
    Status: string,
    Occupation: string,
    ServiceYears: number,
    GrossIncome: number,
    SalaryDeductions: number)
  {
    this.id = ID;
    this.loanID = LoanID;
    this.customerID = CustomerID;
    this.amountApplied = AmountApplied;
    this.interestRate = InterestRate;
    this.EMI_amount = EMI_Amount;
    this.reapaymentPeriod = RepaymentPeriod;
    this.dateOfApplication = DateOfApplication;
    this.status = Status;

    this.occupation = Occupation;
    this.serviceYears = ServiceYears;
    this.grossIncome = GrossIncome;
    this.salaryDeductions = SalaryDeductions;
  }

}
