use Pecunia
go

alter procedure Pecunia.getEduLoanByCustomerID (@customerID uniqueidentifier,
											@loanID uniqueidentifier output,
											@loanStatus varchar(15) output,
											@amountApplied money output,
											@EMI money output,
											@repaymentPeriod tinyint output)
as			
begin
	if(exists (select * from Pecunia.EduLoan where CustomerID=@customerID) )
		begin
			select  @loanID=LoanID,
					@loanStatus = LoanStatus,
					@amountApplied = AmountApplied,
					@EMI = EMI_amount,
					@repaymentPeriod = RepaymentPeriod
			from Pecunia.EduLoan
			where CustomerID = @customerID
		end
	else
		throw 50000, 'Customer dont have a car loan',1
end