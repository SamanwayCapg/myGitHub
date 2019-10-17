use Pecunia
go

create procedure Pecunia.cancelHomeLoan(@loanID uniqueidentifier)
as
begin
	delete from Pecunia.HomeLoan where LoanID = @loanID;
end