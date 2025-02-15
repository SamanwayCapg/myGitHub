use Pecunia
go

alter procedure Pecunia.getCarLoanByLoanID (@loanID uniqueidentifier,
											@customerID uniqueidentifier output,
											@loanStatus varchar(15) output,
											@amountApplied money output,
											@EMI money output,
											@repaymentPeriod tinyint output)
as			
begin
	if(exists (select * from Pecunia.CarLoan where LoanID=@loanID) )
		begin
			select  @customerID=CustomerID,
					@loanStatus = LoanStatus,
					@amountApplied = AmountApplied,
					@EMI = EMI_amount,
					@repaymentPeriod = RepaymentPeriod
			from Pecunia.CarLoan
			where LoanID = @loanID
		end
	else
		throw 50000, 'Loan ID dont exist',1
end