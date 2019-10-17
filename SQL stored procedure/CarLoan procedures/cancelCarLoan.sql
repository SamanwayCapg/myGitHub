use Pecunia
go

create procedure Pecunia.cancelCarLoan(@loanID uniqueidentifier)
as
begin
	delete from Pecunia.CarLoan where LoanID = @loanID;
end