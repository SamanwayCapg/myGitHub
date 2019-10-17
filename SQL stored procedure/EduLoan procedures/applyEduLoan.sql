use Pecunia
go

alter procedure Pecunia.applyEduLoan (	@LoanID uniqueidentifier,
								@CustomerID uniqueidentifier,
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
	
	if(@AmountApplied > 2000000)
		throw 50000, 'Maximum allowed amount is Rs. 20 lakh', 1

	if(@RepaymentPeriod > 96)
		throw 50000, 'Maximum allowed repayment period is 96 months', 1

	insert into Pecunia.EduLoan
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


