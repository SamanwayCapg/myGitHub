use Pecunia
go

create procedure Pecunia.cancelEduLoan(@loanID uniqueidentifier)
as
begin
	delete from Pecunia.EduLoan where LoanID = @loanID;
end