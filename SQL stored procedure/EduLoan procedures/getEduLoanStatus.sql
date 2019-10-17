use Pecunia
go

alter procedure Pecunia.getEduLoanStatus(@loanID uniqueidentifier, @status varchar(15) output)
as
begin
	if(exists (select * from Pecunia.EduLoan where LoanID=@loanID))
		select @status=LoanStatus from Pecunia.EduLoan where LoanID=@loanID
	else
		throw 50000, 'LoanID dont exist', 1
end