use Pecunia
go

create procedure getEduLoanByLoanID (@loanID varchar(40),
											@customerID varchar(40) output,
											@loanStatus varchar(15) output,
											@amountApplied money output,
											@EMI money output,
											@repaymentPeriod tinyint output)
as			
begin
	if(exists (select * from Loans.EduLoan where LoanID=@loanID) )
		begin
			select  @customerID=CustomerID,
					@loanStatus = LoanStatus,
					@amountApplied = AmountApplied,
					@EMI = EMI_amount,
					@repaymentPeriod = RepaymentPeriod
			from Loans.EduLoan
			where LoanID = @loanID
		end
	else
		throw 50000, 'Loan ID dont exist',1
end