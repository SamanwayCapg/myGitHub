export class EduLoan {

  id: number;
  loanID: string;
  customerID: string;
  amountApplied: number;
  interestRate: number;
  EMI_amount: number;
  reapaymentPeriod: number;
  dateOfApplication: string;
  status: string;

  course: string;
  instituteName: string;
  studentID: string;
  repaymentHoliday: number;

  constructor(ID: number,
              LoanID: string,
              CustomerID: string,
              AmountApplied: number,
              InterestRate: number,
              EMI_Amount: number,
              RepaymentPeriod: number,
              DateOfApplication: string,
              Status: string,
              Course: string,
              InstituteName: string,
              StudentID: string,
              RepaymentHoliday: number)
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
    this.course = Course; 
    this.instituteName = InstituteName;
    this.studentID = StudentID;
    this.repaymentHoliday = RepaymentHoliday;
  }

}
