use Pecunia
go

create procedure applyCarLoan (	@LoanID varchar(40),
								@CustomerID varchar(40),
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
	if(len(@LoanID)<>36 or len(@CustomerID)<>36)
		throw 50000, 'All ID length must be 36', 1

	if(@AmountApplied > 2000000)
		throw 50000, 'Maximum allowed amount is Rs. 20 lakh', 1

	if(@RepaymentPeriod > 120)
		throw 50000, 'Maximum allowed repayment period is 120 months', 1

	if(@SalaryDeduction > @GrossIncome)
		throw 50000, 'Salary deductions must not be greater than gross income', 1

	insert into Loans.CarLoan
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


