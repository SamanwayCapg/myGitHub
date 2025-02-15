USE [Pecunia]
GO
/****** Object:  StoredProcedure [dbo].[getHomeLoanByCustomerID]    Script Date: 09-Oct-19 07:22:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter procedure Pecunia.getHomeLoanByCustomerID (@customerID uniqueidentifier,
											@loanID uniqueidentifier output,
											@loanStatus varchar(15) output,
											@amountApplied money output,
											@EMI money output,
											@repaymentPeriod tinyint output)
as			
begin
	if(exists (select * from Pecunia.HomeLoan where CustomerID=@customerID) )
		begin
			select  @loanID=LoanID,
					@loanStatus = LoanStatus,
					@amountApplied = AmountApplied,
					@EMI = EMI_amount,
					@repaymentPeriod = RepaymentPeriod
			from Pecunia.HomeLoan
			where CustomerID = @customerID
		end
	else
		throw 50000, 'Customer dont have a home loan',1
end