use Pecunia
go

create procedure getHomeLoanStatus(@loanID varchar(40), @status varchar(15) output)
as
begin
	if(exists (select * from Loans.HomeLoan where LoanID=@loanID))
		select @status=LoanStatus from Loans.HomeLoan where LoanID=@loanID
	else
		throw 50000, 'LoanID dont exist', 1
end