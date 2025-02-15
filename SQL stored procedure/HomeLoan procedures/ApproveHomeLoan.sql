use Pecunia
go

alter procedure Pecunia.approveHomeLoan (@LoanID uniqueidentifier, @updatedStatus varchar(15))
as
begin
	if(exists (select * from Pecunia.HomeLoan where LoanID=@LoanID) )
		begin
			if(@updatedStatus = (select LoanStatus from Pecunia.HomeLoan where LoanID=@LoanID))		
				throw 50000, 'Status cant be updated to existing status', 1

			update Pecunia.HomeLoan set LoanStatus=@updatedStatus
			where LoanID=@LoanID
		end
	else
		throw 50000, 'LoanID not found',1
end