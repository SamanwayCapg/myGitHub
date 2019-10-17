use Pecunia
go

alter procedure Pecunia.getCarLoanStatus(@loanID uniqueidentifier, @status varchar(15) output)
as
begin
	if(exists (select * from Pecunia.CarLoan where LoanID=@loanID))
		select @status=LoanStatus from Pecunia.CarLoan where LoanID=@loanID
	else
		throw 50000, 'LoanID dont exist', 1
end

