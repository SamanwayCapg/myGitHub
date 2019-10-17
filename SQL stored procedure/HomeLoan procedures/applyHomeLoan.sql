use Pecunia
go

alter procedure Pecunia.applyHomeLoan (	@LoanID uniqueidentifier,
								@CustomerID uniqueidentifier,
								@AmountApplied money,
								@InterestRate money,
								@EMI_amount money,
								@RepaymentPeriod tinyint,
								@DateOfApplication datetime,
								@LoanStatus varchar(15),
							
								@Occupation varchar(15),
								@ServiceYears tinyint,
								@GrossIncome money,
								@SalaryDeduction money)
as 
begin

	if(@AmountApplied > 2000000 and @AmountApplied>0)
		throw 50000, 'Maximum allowed amount is Rs. 20 lakh and figure must be positive', 1

	if(@RepaymentPeriod > 120 and @RepaymentPeriod>0)
		throw 50000, 'Maximum allowed repayment period is 120 months and figure must be positive', 1

	if(@SalaryDeduction > @GrossIncome)
		throw 50000, 'Salary deductions must not be greater than gross income', 1

	if(@ServiceYears < 5 and @ServiceYears>0)
		throw 50000, 'Must have a minimum service experience of 5 years and figure must be positive', 1

	if(@SalaryDeduction<0 or @GrossIncome<=0)
		throw 50000, 'salary and deduction figures must be positive', 1

	insert into Pecunia.HomeLoan
	values( @LoanID,
			@CustomerID,
			@AmountApplied,
			@InterestRate,
			@EMI_amount,
			@RepaymentPeriod,
			@DateOfApplication,
			@LoanStatus,

			@Occupation,
			@ServiceYears,
			@GrossIncome,
			@SalaryDeduction)
end


