use Pecunia
go

create procedure approveEduLoan (@LoanID varchar(40), @updatedStatus varchar(15))
as
begin
	if(exists (select * from Loans.EduLoan where LoanID=@LoanID) )
		begin
			if(@updatedStatus = (select LoanStatus from Loans.EduLoan where LoanID=@LoanID))		
				throw 50000, 'Status cant be updated to existing status', 1

			update Loans.EduLoan set LoanStatus=@updatedStatus
			where LoanID=@LoanID
		end
	else
		throw 50000, 'LoanID not found',1
end