export class CarLoan {

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
  grossIncome: number;
  salaryDeductions: number;
  vehicle: string;
 // constructor() {}

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
    GrossIncome: number,
    SalaryDeductions: number,
    Vehicle: string)
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
    this.grossIncome = GrossIncome;
    this.salaryDeductions = SalaryDeductions;
    this.vehicle = Vehicle;
  }
 
}
