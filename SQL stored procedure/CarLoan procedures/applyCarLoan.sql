use Pecunia
go

alter procedure Pecunia.applyCarLoan (	@LoanID uniqueidentifier,
								@CustomerID uniqueidentifier,
								@AmountApplied money,
								@InterestRate money,
								@EMI_amount money,
								@RepaymentPeriod tinyint,
								@DateOfApplication datetime,
								@LoanStatus varchar(15),
								
								@Occupation varchar(15),
								@GrossIncome money,
								@SalaryDeduction money,
								@VehicleType varchar(15))
as 
begin
	
	if(@AmountApplied > 2000000)
		throw 50000, 'Maximum allowed amount is Rs. 20 lakh', 1

	if(@RepaymentPeriod > 120)
		throw 50000, 'Maximum allowed repayment period is 120 months', 1

	if(@SalaryDeduction > @GrossIncome)
		throw 50000, 'Salary deductions must not be greater than gross income', 1

	insert into Pecunia.CarLoan
	values( @LoanID,
			@CustomerID,
			@AmountApplied,
			@InterestRate,
			@EMI_amount,
			@RepaymentPeriod,
			@DateOfApplication,
			@LoanStatus,
			
			@Occupation,
			@GrossIncome,
			@SalaryDeduction,
			@VehicleType)
end


