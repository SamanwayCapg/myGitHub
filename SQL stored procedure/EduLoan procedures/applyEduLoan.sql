use Pecunia
go

create procedure applyEduLoan (	@LoanID varchar(40),
								@CustomerID varchar(40),
								@AmountApplied money,
								@InterestRate money,
								@EMI_amount money,
								@RepaymentPeriod tinyint,
								@DateOfApplication datetime,
								@LoanStatus varchar(15),
								
								@Course varchar(15),
								@InstituteName varchar(50),
								@StudentID varchar(20),
								@RepaymentHoliday tinyint)
as 
begin
	if(len(@LoanID)<>36 or len(@CustomerID)<>36)
		throw 50000, 'All ID length must be 36', 1

	if(@AmountApplied > 2000000)
		throw 50000, 'Maximum allowed amount is Rs. 20 lakh', 1

	if(@RepaymentPeriod > 96)
		throw 50000, 'Maximum allowed repayment period is 96 months', 1

	insert into Loans.EduLoan
	values( @LoanID,
			@CustomerID,
			@AmountApplied,
			@InterestRate,
			@EMI_amount,
			@RepaymentPeriod,
			@DateOfApplication,
			@LoanStatus,

			@Course,
			@InstituteName,
			@StudentID,
			@RepaymentHoliday)
end


