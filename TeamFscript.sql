USE [13th Aug CLoud PT Immersive]
GO
/****** Object:  Table [TeamF].[Account]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[Account](
	[AccountID] [uniqueidentifier] NOT NULL,
	[AccountNumber] [bigint] NULL,
	[HomeBranch] [varchar](20) NULL,
	[Feedback] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[DateOfCreation] [datetime] NULL,
	[AccountType] [varchar](7) NULL,
	[AccountBalance] [money] NULL,
	[CustomerID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamF].[Admins]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[Admins](
	[AdminID] [uniqueidentifier] NOT NULL,
	[AdminName] [varchar](40) NOT NULL,
	[AdminEmail] [dbo].[Email] NOT NULL,
	[AdminPassword] [dbo].[Password] NOT NULL,
	[CreationDateTime] [datetime] NULL,
	[LastModifiedDateTime] [datetime] NULL,
	[IsActive] [bit] NULL,
	[EmployeeID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamF].[CarLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[CarLoan](
	[LoanID] [uniqueidentifier] NOT NULL,
	[CustomerID] [uniqueidentifier] NULL,
	[AmountApplied] [money] NULL,
	[InterestRate] [decimal](10, 2) NULL,
	[EMI_amount] [money] NULL,
	[RepaymentPeriod] [tinyint] NULL,
	[DateOfApplication] [datetime] NULL,
	[LoanStatus] [varchar](15) NULL,
	[Occupation] [varchar](15) NULL,
	[GrossIncome] [money] NULL,
	[SalaryDeduction] [money] NULL,
	[VehicleType] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[LoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamF].[Customers]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[Customers](
	[CustomerID] [uniqueidentifier] NOT NULL,
	[CustomerName] [varchar](40) NOT NULL,
	[CustomerAddress] [varchar](200) NULL,
	[CustomerMobile] [char](10) NOT NULL,
	[CustomerEmail] [varchar](40) NULL,
	[CustomerPan] [char](10) NULL,
	[CustomerAadhaarNumber] [char](12) NULL,
	[DOB] [datetime] NULL,
	[CustomerGender] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamF].[EduLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[EduLoan](
	[LoanID] [uniqueidentifier] NOT NULL,
	[CustomerID] [uniqueidentifier] NULL,
	[AmountApplied] [money] NULL,
	[InterestRate] [decimal](18, 0) NULL,
	[EMI_amount] [money] NULL,
	[RepaymentPeriod] [tinyint] NULL,
	[DateOfApplication] [datetime] NULL,
	[LoanStatus] [varchar](15) NULL,
	[Course] [varchar](15) NULL,
	[InstituteName] [varchar](50) NULL,
	[StudentID] [varchar](20) NULL,
	[RepaymentHoliday] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamF].[Employees]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[Employees](
	[EmployeeID] [uniqueidentifier] NOT NULL,
	[EmployeeName] [varchar](40) NOT NULL,
	[EmployeeEmail] [dbo].[Email] NOT NULL,
	[EmployeePassword] [dbo].[Password] NOT NULL,
	[Mobile] [char](10) NULL,
	[CreationDateTime] [datetime] NULL,
	[LastModifiedDateTime] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamF].[FixedDeposit]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[FixedDeposit](
	[AccountID] [uniqueidentifier] NOT NULL,
	[FdDeposit] [bigint] NULL,
	[InterestRate] [float] NULL,
	[Tenure] [int] NULL,
	[AccountNumber] [bigint] NULL,
	[HomeBranch] [varchar](20) NULL,
	[CustomerID] [uniqueidentifier] NULL,
	[Feedback] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[DateOfCreation] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamF].[HomeLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[HomeLoan](
	[LoanID] [uniqueidentifier] NOT NULL,
	[CustomerID] [uniqueidentifier] NULL,
	[AmountApplied] [money] NULL,
	[InterestRate] [decimal](18, 0) NULL,
	[EMI_amount] [money] NULL,
	[RepaymentPeriod] [tinyint] NULL,
	[DateOfApplication] [datetime] NULL,
	[LoanStatus] [varchar](15) NULL,
	[Occupation] [varchar](15) NULL,
	[ServiceYears] [tinyint] NULL,
	[GrossIncome] [money] NULL,
	[SalaryDeduction] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamF].[Transactions]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamF].[Transactions](
	[TransactionID] [uniqueidentifier] NOT NULL,
	[AccountID] [uniqueidentifier] NULL,
	[TypeOfTransaction] [varchar](6) NOT NULL,
	[Amount] [money] NOT NULL,
	[DateOfTransaction] [datetime] NULL,
	[Mode] [varchar](14) NOT NULL,
	[ChequeNumber] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [TeamF].[Account]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [TeamF].[Customers] ([CustomerID])
GO
ALTER TABLE [TeamF].[Admins]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [TeamF].[Employees] ([EmployeeID])
GO
ALTER TABLE [TeamF].[CarLoan]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [TeamF].[Customers] ([CustomerID])
ON UPDATE CASCADE
GO
ALTER TABLE [TeamF].[EduLoan]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [TeamF].[Customers] ([CustomerID])
ON UPDATE CASCADE
GO
ALTER TABLE [TeamF].[FixedDeposit]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [TeamF].[Customers] ([CustomerID])
GO
ALTER TABLE [TeamF].[HomeLoan]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [TeamF].[Customers] ([CustomerID])
ON UPDATE CASCADE
GO
ALTER TABLE [TeamF].[Transactions]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [TeamF].[Account] ([AccountID])
ON UPDATE CASCADE
GO
/****** Object:  StoredProcedure [TeamF].[AddAccountDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[AddAccountDAL](@AccountType varchar(7),@AccountNumber bigint,@AccountID uniqueidentifier
,@CustomerID uniqueidentifier,@HomeBranch varchar(20),
@IsActive bit)	

as 
begin
declare @Feedback varchar(100);
declare @DateOfCreation dateTime,@AccountBalance money;
set @DateOfCreation = SysDatetime(); 
set @Feedback = '';
set @AccountBalance = 0;



if(exists(select 1 from TeamF.Account where AccountID = @AccountID))
throw 50000,'AccountID Already Exists ',1





insert  into TeamF.Account (AccountID,AccountNumber,HomeBranch,AccountType
,CustomerID,DateOfCreation,Feedback,IsActive,AccountBalance) values(@AccountID,@AccountNumber,@HomeBranch,@AccountType,@CustomerID,
@DateOfCreation,@FeedBack,@IsActive,@AccountBalance)

end
GO
/****** Object:  StoredProcedure [TeamF].[AddAccountDAL1]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [TeamF].[AddAccountDAL1] 
(@AccountID uniqueidentifier,@CustomerID uniqueidentifier,@AccountType varchar(7),@AccountNumber bigint,@HomeBranch varchar(20),
@IsActive bit)
as
begin

declare @Feedback varchar(100);
declare @DateOfCreation dateTime,@AccountBalance money;
set @DateOfCreation = SysDatetime(); 
set @Feedback = '';
set @AccountBalance = 0;


if(exists(select 1 from TeamF.Account where AccountID = @AccountID))
throw 50000,'AccountID Already Exists ',1

insert into TeamF.Account (AccountID,CustomerID,DateOfCreation,Feedback,IsActive,AccountBalance,AccountNumber,HomeBranch,AccountType) 
values (@AccountID,@CustomerID,@DateOfCreation,@FeedBack,@IsActive,@AccountBalance,@AccountNumber,@HomeBranch,@AccountType
)
end
GO
/****** Object:  StoredProcedure [TeamF].[AddAdmin]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[AddAdmin](@adminid uniqueidentifier,@adminname varchar(40), @adminemail Email, @adminpassword Password)
as
begin
	DECLARE @creationDate datetime = SYSDATETIME();
	DECLARE @lastModifiedDateTime datetime = SYSDATETIME();
	DECLARE @isActive bit = 1;
	
	if @adminname = ''
	throw 50001, 'Name cannot be blank', 1
	if @adminemail is null 
	throw 50001, 'Email cannot be blank', 1
	if exists (select AdminEmail from TeamF.Admins where AdminEmail = @adminemail)
	throw 50001, 'Email already exists', 1
	if @adminpassword is null
	throw 50001, 'Password cannot be blank', 1
	else
	insert into TeamF.Admins(AdminID, AdminName, AdminEmail, AdminPassword,CreationDateTime, LastModifiedDateTime, isActive) 
	values (@adminid, @adminname, @adminemail, @adminpassword, @creationDate, @lastModifiedDateTime, @isActive) 
end

GO
/****** Object:  StoredProcedure [TeamF].[AddCustomerDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamF].[AddCustomerDAL](@CustomerID uniqueidentifier, @CustomerName varchar(40),@CustomerAddress varchar(100),@CustomerMobile char(10),@CustomerEmail varchar(40),@CustomerPan char(10),@CustomerAadhaarNumber char(12),@DOB datetime,@CustomerGender varchar(12)) 
As
Begin
     
	if(len(@CustomerName) <2 OR len(@CustomerName)>40)
	throw 50000 ,'Customer Name not in correct format',1;

	if (@CustomerName is null)
	throw 50000 ,'Customer Name invalid ',1;


   
   if(len(@CustomerPan) <>10)
   throw 50000 ,'CustomerPan not in correct format',1;

   if (@CustomerPan is null)
   throw 50000 ,'Customer Pan invalid ',1;
   
   

   Insert into TeamF.Customers( CustomerID, CustomerName ,CustomerAddress,CustomerMobile,CustomerEmail,CustomerPan,CustomerAadhaarNumber,DOB,CustomerGender)
   Values(@CustomerID , @CustomerName ,@CustomerAddress,@CustomerMobile,@CustomerEmail,@CustomerPan,@CustomerAadhaarNumber,@DOB,@CustomerGender)
END
GO
/****** Object:  StoredProcedure [TeamF].[AddEmployees]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[AddEmployees](@empid uniqueidentifier,@empname varchar(40), @empemail Email, @emppassword Password, @empmobile char(10))
as
begin
DECLARE @creationDate datetime = SYSDATETIME();
DECLARE @lastModifiedDateTime datetime = SYSDATETIME();
DECLARE @isActive bit = 1;
	--if exists (select EmployeeID from TeamF.Employees where EmployeeID = @empid)
	--throw 50001, 'Employee ID already exists', 1
	if @empname = ''
	throw 50001, 'Name cannot be blank', 1
	if @empemail is null 
	throw 50001, 'Email cannot be blank', 1
	if exists (select EmployeeEmail from TeamF.Employees where EmployeeEmail = @empemail)
	throw 50001, 'Email already exists', 1
	if @emppassword is null
	throw 50001, 'Password cannot be blank', 1
	if @empmobile is null
	throw 50001, 'Mobile cannot be blank', 1
	if 	exists (select Mobile from TeamF.Employees where Mobile = @empmobile)
	throw 50001, 'Mobile number already exists', 1
	else
	insert into TeamF.Employees(EmployeeID, EmployeeName, EmployeeEmail, EmployeePassword, Mobile, CreationDateTime, LastModifiedDateTime, isActive) 
	values (@empid, @empname, @empemail, @emppassword, @empmobile, @creationDate, @lastModifiedDateTime, @isActive) 
end

GO
/****** Object:  StoredProcedure [TeamF].[AddFixedDepositDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[AddFixedDepositDAL](@AccountNumber bigint,@AccountID uniqueidentifier
,@CustomerID uniqueidentifier,@HomeBranch varchar(20),
@IsActive bit,@FdDeposit money,@InterestRate money,@Tenure int)

As

begin
--Givinng inital Feedback as Null and giving system Date and Time
declare @DateOfCreation dateTime;
set @DateOfCreation = SysDatetime();  
 declare @Feedback varchar(100);
 set @Feedback='';

 --Throw exception if  deposit is less than 20000
if(@FdDeposit < 20000)
throw 50000,'Minimum FD Deposit is 20000',1;

if(exists(select 1 from Accounts.FixedDeposit where AccountID = @AccountID))
throw 50000,'AccountID Already Exists add new Account ',1

--If account ID is Blank then throw exception
if(@AccountID = '')
throw 50000,'AccountID cannot be blank',1

--inserting into Table
insert  into Accounts.FixedDeposit (AccountID,FdDeposit ,InterestRate ,Tenure  ,AccountNumber ,
HomeBranch ,CustomerID ,Feedback ,IsActive ,DateOfCreation) values(@AccountID,@FdDeposit,@InterestRate ,@Tenure,@AccountNumber,
@HomeBranch ,@CustomerID ,@Feedback ,@IsActive ,@DateOfCreation)

end
GO
/****** Object:  StoredProcedure [TeamF].[AddFixedDepositDAL1]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[AddFixedDepositDAL1] (@AccountID uniqueidentifier,@CustomerID uniqueidentifier,@AccountNumber bigint,@HomeBranch varchar(20),
@IsActive bit,@Tenure int,@FdDeposit money, @InterestRate money)

As

begin
--Givinng inital Feedback as Null and giving system Date and Time
declare @DateOfCreation dateTime;
set @DateOfCreation = SysDatetime();  
 declare @Feedback varchar(100);
 set @Feedback='';


if(exists(select 1 from TeamF.FixedDeposit where AccountID = @AccountID))
throw 50000,'AccountID Already Exists add new Account ',1


--inserting into Table
insert  into TeamF.FixedDeposit (AccountID,FdDeposit ,InterestRate ,Tenure  ,AccountNumber ,
HomeBranch ,CustomerID ,Feedback ,IsActive ,DateOfCreation) values(@AccountID,@FdDeposit,@InterestRate ,@Tenure,@AccountNumber,
@HomeBranch ,@CustomerID ,@Feedback ,@IsActive ,@DateOfCreation)

end
GO
/****** Object:  StoredProcedure [TeamF].[AddFixedDepositDAL2]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamF].[AddFixedDepositDAL2] 
(@AccountID uniqueidentifier,@CustomerID uniqueidentifier,@FdDeposit money,@AccountNumber bigint,@HomeBranch varchar(20),
@IsActive bit,@InterestRate money,@Tenure int)
as
begin

declare @Feedback varchar(100);
declare @DateOfCreation dateTime,@AccountBalance money;
set @DateOfCreation = SysDatetime(); 
set @Feedback = '';
set @AccountBalance = 0;


if(exists(select 1 from TeamF.Account where AccountID = @AccountID))
throw 50000,'AccountID Already Exists ',1

insert into TeamF.FixedDeposit (AccountID,CustomerID,DateOfCreation,Feedback,IsActive,AccountNumber,HomeBranch,
FdDeposit,InterestRate,Tenure) 
values (@AccountID,@CustomerID,@DateOfCreation,@FeedBack,@IsActive,@AccountNumber,@HomeBranch,@FdDeposit,
@InterestRate,@Tenure)
end

GO
/****** Object:  StoredProcedure [TeamF].[applyCarLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[applyCarLoan] (	@LoanID uniqueidentifier,
								@CustomerID uniqueidentifier,
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
	
	if(@AmountApplied > 2000000)
		throw 50000, 'Maximum allowed amount is Rs. 20 lakh', 1

	if(@RepaymentPeriod > 120)
		throw 50000, 'Maximum allowed repayment period is 120 months', 1

	if(@SalaryDeduction > @GrossIncome)
		throw 50000, 'Salary deductions must not be greater than gross income', 1

	insert into TeamF.CarLoan
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



GO
/****** Object:  StoredProcedure [TeamF].[applyEduLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[applyEduLoan] (	@LoanID uniqueidentifier,
								@CustomerID uniqueidentifier,
								@AmountApplied money,
								@InterestRate money,
								@EMI_amount money,
								@RepaymentPeriod tinyint,
								@DateOfApplication datetime,
								@LoanStatus varchar(15),
								
								@Course varchar(15),
								@InstituteName varchar(50),
								@StudentID varchar(20),
								@RepaymentHoliday tinyint)
as 
begin
	
	if(@AmountApplied > 2000000)
		throw 50000, 'Maximum allowed amount is Rs. 20 lakh', 1

	if(@RepaymentPeriod > 96)
		throw 50000, 'Maximum allowed repayment period is 96 months', 1

	insert into TeamF.EduLoan
	values( @LoanID,
			@CustomerID,
			@AmountApplied,
			@InterestRate,
			@EMI_amount,
			@RepaymentPeriod,
			@DateOfApplication,
			@LoanStatus,

			@Course,
			@InstituteName,
			@StudentID,
			@RepaymentHoliday)
end



GO
/****** Object:  StoredProcedure [TeamF].[applyHomeLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[applyHomeLoan] (	@LoanID uniqueidentifier,
								@CustomerID uniqueidentifier,
								@AmountApplied money,
								@InterestRate money,
								@EMI_amount money,
								@RepaymentPeriod tinyint,
								@DateOfApplication datetime,
								@LoanStatus varchar(15),
							
								@Occupation varchar(15),
								@ServiceYears tinyint,
								@GrossIncome money,
								@SalaryDeduction money)
as 
begin

	if(@AmountApplied > 2000000 and @AmountApplied>0)
		throw 50000, 'Maximum allowed amount is Rs. 20 lakh and figure must be positive', 1

	if(@RepaymentPeriod > 120 and @RepaymentPeriod>0)
		throw 50000, 'Maximum allowed repayment period is 120 months and figure must be positive', 1

	if(@SalaryDeduction > @GrossIncome)
		throw 50000, 'Salary deductions must not be greater than gross income', 1

	if(@ServiceYears < 5 and @ServiceYears>0)
		throw 50000, 'Must have a minimum service experience of 5 years and figure must be positive', 1

	if(@SalaryDeduction<0 or @GrossIncome<=0)
		throw 50000, 'salary and deduction figures must be positive', 1

	insert into TeamF.HomeLoan
	values( @LoanID,
			@CustomerID,
			@AmountApplied,
			@InterestRate,
			@EMI_amount,
			@RepaymentPeriod,
			@DateOfApplication,
			@LoanStatus,

			@Occupation,
			@ServiceYears,
			@GrossIncome,
			@SalaryDeduction)
end



GO
/****** Object:  StoredProcedure [TeamF].[approveCarLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[approveCarLoan] (@LoanID uniqueidentifier, @updatedStatus varchar(15))
as
begin
	if(exists (select * from TeamF.CarLoan where LoanID=@LoanID) )
		begin
			if(@updatedStatus = (select LoanStatus from TeamF.CarLoan where LoanID=@LoanID))		
				throw 50000, 'Status cant be updated to existing status', 1

			update TeamF.CarLoan set LoanStatus=@updatedStatus
			where LoanID=@LoanID
		end
	else
		throw 50000, 'LoanID not found',1
end
GO
/****** Object:  StoredProcedure [TeamF].[approveEduLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[approveEduLoan] (@LoanID uniqueidentifier, @updatedStatus varchar(15))
as
begin
	if(exists (select * from TeamF.EduLoan where LoanID=@LoanID) )
		begin
			if(@updatedStatus = (select LoanStatus from TeamF.EduLoan where LoanID=@LoanID))		
				throw 50000, 'Status cant be updated to existing status', 1

			update TeamF.EduLoan set LoanStatus=@updatedStatus
			where LoanID=@LoanID
		end
	else
		throw 50000, 'LoanID not found',1
end
GO
/****** Object:  StoredProcedure [TeamF].[approveHomeLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[approveHomeLoan] (@LoanID uniqueidentifier, @updatedStatus varchar(15))
as
begin
	if(exists (select * from TeamF.HomeLoan where LoanID=@LoanID) )
		begin
			if(@updatedStatus = (select LoanStatus from TeamF.HomeLoan where LoanID=@LoanID))		
				throw 50000, 'Status cant be updated to existing status', 1

			update TeamF.HomeLoan set LoanStatus=@updatedStatus
			where LoanID=@LoanID
		end
	else
		throw 50000, 'LoanID not found',1
end
GO
/****** Object:  StoredProcedure [TeamF].[cancelCarLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[cancelCarLoan](@loanID uniqueidentifier)
as
begin
	delete from TeamF.CarLoan where LoanID = @loanID;
end
GO
/****** Object:  StoredProcedure [TeamF].[cancelEduLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[cancelEduLoan](@loanID uniqueidentifier)
as
begin
	delete from TeamF.EduLoan where LoanID = @loanID;
end
GO
/****** Object:  StoredProcedure [TeamF].[cancelHomeLoan]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [TeamF].[cancelHomeLoan](@loanID uniqueidentifier)
as
begin
	delete from TeamF.HomeLoan where LoanID = @loanID;
end
GO
/****** Object:  StoredProcedure [TeamF].[ChangeAccountType1]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[ChangeAccountType1](@AccountID uniqueidentifier,@AccountType varchar(7))
as 
begin

--Change Home Branch if AccountID matches
update TeamF.Account 
set AccountType = @AccountType where AccountID =  @AccountID and IsActive=1

end
GO
/****** Object:  StoredProcedure [TeamF].[ChangeBranchofAccount]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[ChangeBranchofAccount](@AccountID uniqueidentifier,@HomeBranch varchar(20))
as 
begin


--Change Home Branch if AccountID matches
update TeamF.Account 
set HomeBranch = @HomeBranch where AccountID =  @AccountID

end
GO
/****** Object:  StoredProcedure [TeamF].[ChangeBranchofAccount1]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[ChangeBranchofAccount1](@AccountID uniqueidentifier,@HomeBranch varchar(20))
as 
begin


--Change Home Branch if AccountID matches
update TeamF.Account 
set HomeBranch = @HomeBranch where AccountID =  @AccountID and IsActive=1

end
GO
/****** Object:  StoredProcedure [TeamF].[ChangeBranchofFixedDeposit]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[ChangeBranchofFixedDeposit](@AccountID uniqueidentifier,@HomeBranch varchar(20))
as 
begin

--If Home Branch is Null then throw exception


--Change Home Branch if AccountID matches
update TeamF.FixedDeposit 
set HomeBranch = @HomeBranch where AccountID =  @AccountID and IsActive=1

end
GO
/****** Object:  StoredProcedure [TeamF].[ChangeFDDeposit]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [TeamF].[ChangeFDDeposit](@AccountID uniqueidentifier,@FdDeposit money)
as
begin


--Update FixedDeposit if AccountID matches
Update TeamF.FixedDeposit 
set FdDeposit = @FdDeposit where AccountID = @AccountID and IsActive=1;
end
GO
/****** Object:  StoredProcedure [TeamF].[CreditBalance]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[CreditBalance](@accountID uniqueidentifier, @amount money)
as
begin
update TeamF.Account
set AccountBalance = AccountBalance + @amount
where AccountID = @accountID
end
GO
/****** Object:  StoredProcedure [TeamF].[CreditTransactionByCheque]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[CreditTransactionByCheque](@accountID uniqueidentifier, @typeOfTranscation varchar(6), @amount money, @modeOfTransaction varchar(14), @chequeNumber char(6))
as
begin
	declare @dateofTransaction datetime = SYSDATETIME()
	declare @transactionID uniqueidentifier = newid()
	

	if @amount is null or @amount < 0 or @amount > 50000
			throw 500000,'Enter Correct amount',1;
	if len(ISNULL(@chequeNumber,''))<>6
			throw 500000,'Enter Correct cheque',1;
begin try
	insert into TeamF.Transactions( AccountID, TypeOFTransaction, Amount, TransactionID, DateOfTransaction, Mode, ChequeNumber)
	values ( @accountID, @typeOfTranscation, @amount, @transactionID, @dateofTransaction ,
            @modeOfTransaction, @chequeNumber)
end try

begin catch
	throw;
end catch
end
GO
/****** Object:  StoredProcedure [TeamF].[CreditTransactionByDepositSlip]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[CreditTransactionByDepositSlip](@accountNumber bigint, @accountID uniqueidentifier, @typeOfTranscation varchar(6), @amount money, @modeOfTransaction varchar(14), @chequeNumber char(6))
as
begin
	declare @dateofTransaction datetime = SYSDATETIME()
	declare @transactionID uniqueidentifier = newid()
	
	if @accountNumber < 300000 or @amount > 599999
			throw 500000,'Enter Correct amount',1;
	if @amount is null or @amount < 0 or @amount > 50000
			throw 500000,'Enter Correct amount',1;
begin try
	insert into TeamF.Transactions(AccountNumber, AccountID, TypeOFTransaction, Amount, TransactionID, DateOfTransaction, ModeOfTransaction, ChequeNumber)
	values (@accountNumber, @accountID, @typeOfTranscation, @amount, @transactionID, @dateofTransaction ,
            @modeOfTransaction, @chequeNumber)
end try

begin catch
	throw;
end catch
end
GO
/****** Object:  StoredProcedure [TeamF].[DebitBalance]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[DebitBalance](@accountID uniqueidentifier, @amount money)
as
begin
update TeamF.Account
set AccountBalance = AccountBalance - @amount
where AccountID = @accountID
end
GO
/****** Object:  StoredProcedure [TeamF].[DebitBalanceC]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[DebitBalanceC](@accountID uniqueidentifier, @amount money, @chequeNumber char(6))
as
begin
--declare @accountbalance money
--set @accountbalance = (Select AccountBalance from TeamF.Account) - (@amount) 
update TeamF.Account
set AccountBalance = AccountBalance - @amount
Where AccountID = @accountID

Insert into TeamF.Transactions(ChequeNumber , AccountID , Amount ) Values  (@chequeNumber , @accountID , @amount  ) 
 

end
GO
/****** Object:  StoredProcedure [TeamF].[DebitTransactionByCheque]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[DebitTransactionByCheque](@accountID uniqueidentifier, @typeOfTranscation varchar(6), @amount money, @modeOfTransaction varchar(14), @chequeNumber char(6))
as
begin
	declare @dateofTransaction datetime = SYSDATETIME()
	declare @transactionID uniqueidentifier = newid()
	
	
	if @amount is null or @amount < 0 or @amount > 50000
			throw 500000,'Enter Correct amount',1;
	if len(ISNULL(@chequeNumber,''))<>6
			throw 500000,'Enter Correct cheque',1;
begin try
	insert into TeamF.Transactions( AccountID, TypeOFTransaction, Amount, TransactionID, DateOfTransaction, Mode, ChequeNumber)
	values ( @accountID, @typeOfTranscation, @amount, @transactionID, @dateofTransaction ,
            @modeOfTransaction, @chequeNumber)
end try

begin catch
	throw;
end catch
end
GO
/****** Object:  StoredProcedure [TeamF].[DebitTransactionByWithdrawalSlip]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[DebitTransactionByWithdrawalSlip](@accountID uniqueidentifier, @type varchar(6), @amount money, @mode varchar(14), @chequeNumber char(6))
as
begin
	declare @dateofTransaction datetime = SYSDATETIME()
	declare @transactionID uniqueidentifier = newid()
	
	
	if @amount is null or @amount < 0 or @amount > 50000
			throw 500000,'Enter Correct amount',1;
begin try
	insert into TeamF.Transactions( AccountID, TypeOfTransaction, Amount, TransactionID, DateOfTransaction, Mode, ChequeNumber)
	values ( @accountID, @type, @amount, @transactionID, @dateofTransaction ,
            @mode, @chequeNumber)
end try

begin catch
	throw;
end catch
end
GO
/****** Object:  StoredProcedure [TeamF].[DeleteAccountDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[DeleteAccountDAL](@AccountID uniqueidentifier,@FeedBack varchar(100))

as 
begin
--If AccountID Null then throw exception
if(@AccountID = '' )
throw 50000,'AccountID cannot be Null',1

--Setting the IsActive STatus to 0 of the given AccountID.
update TeamF.Account 
set IsActive = 0, Feedback = @Feedback  where AccountID = @AccountID;
end
GO
/****** Object:  StoredProcedure [TeamF].[DeleteAccountDAL1]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[DeleteAccountDAL1](@AccountID uniqueidentifier, @Feedback varchar(100))

as 
begin
--If AccountID Null then throw exception


--Setting the IsActive STatus to 0 of the given AccountID.
update TeamF.Account 
set IsActive = 0,Feedback =@Feedback where (AccountID = @AccountID and IsActive=1);
end
GO
/****** Object:  StoredProcedure [TeamF].[DeleteEmployee]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[DeleteEmployee](@empid uniqueidentifier)
as
begin
	if not exists(select EmployeeID from TeamF.Employees where EmployeeID = @empid)
	throw 50011, 'Employee ID not found',1
	--update TeamF.Employees set IsActive = 0 where EmployeeID = @empid
	delete from TeamF.Employees where EmployeeID = @empid
end

GO
/****** Object:  StoredProcedure [TeamF].[DeleteFixedDepositDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamF].[DeleteFixedDepositDAL](@AccountID uniqueidentifier,@Feedback varchar(100))

as 
begin

--If AccountID Null then throw exception
if(@AccountID = '' )
throw 50000,'AccountID cannot be Null',1
 
--Setting the IsActive STatus to 0 of the given AccountID.
update TeamF.FixedDeposit
set IsActive = 0,Feedback = @Feedback where AccountID = @AccountID;

end
GO
/****** Object:  StoredProcedure [TeamF].[DeleteFixedDepositDAL1]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[DeleteFixedDepositDAL1](@AccountID uniqueidentifier,@Feedback varchar(100))	

as 
begin

--If AccountID Null then throw exception

 
--Setting the IsActive STatus to 0 of the given AccountID.
update TeamF.FixedDeposit
set IsActive = 0, Feedback=@Feedback where (AccountID = @AccountID and IsActive=1);

end
GO
/****** Object:  StoredProcedure [TeamF].[FdAdding]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamF].[FdAdding] (@CustomerID uniqueidentifier,@AccountID uniqueidentifier,@HomeBranch varchar(20),@Tenure int,
@FdDeposit money,@InterestRate money,@AccountNumber bigint,@IsActive bit)
as
begin

declare @Feedback varchar(100);
declare @DateOfCreation dateTime,@AccountBalance money;
set @DateOfCreation = SysDatetime(); 
set @Feedback = '';

insert into TeamF.FixedDeposit (AccountID,FdDeposit,InterestRate,Tenure,AccountNumber,HomeBranch,CustomerID,Feedback,IsActive,DateOfCreation)
values (@AccountID,@FdDeposit,@InterestRate,@Tenure,@AccountNumber,@HomeBranch,@CustomerID,@Feedback,@IsActive,@DateOfCreation)
end
GO
/****** Object:  StoredProcedure [TeamF].[GetAccountByAccountID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[GetAccountByAccountID](@AccountID uniqueidentifier)
as 
begin

select * from TeamF.Account where AccountID = @AccountID;

end
GO
/****** Object:  StoredProcedure [TeamF].[GetAccountByAccountID1]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[GetAccountByAccountID1](@AccountID uniqueidentifier)
as 
begin

select * from TeamF.Account where AccountID = @AccountID and IsActive=1;

end
GO
/****** Object:  StoredProcedure [TeamF].[GetAccountByCustomerID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[GetAccountByCustomerID](@CustomerID uniqueidentifier)
as 
begin

select * from TeamF.Account where CustomerID = @CustomerID;

end
GO
/****** Object:  StoredProcedure [TeamF].[GetAccountByCustomerID1]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[GetAccountByCustomerID1](@CustomerID uniqueidentifier)
as 
begin

select * from TeamF.Account where CustomerID = @CustomerID and IsActive =1;

end
GO
/****** Object:  StoredProcedure [TeamF].[GetAdminByAdminID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[GetAdminByAdminID](@adminID uniqueidentifier)
as
begin
	if not exists(select AdminID from TeamF.Admins where AdminID = @adminID)
		throw 50012, 'Admin ID not found',1
	else
		select * from TeamF.Admins
end
GO
/****** Object:  StoredProcedure [TeamF].[GetAdminByEmailandPassword]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[GetAdminByEmailandPassword](@adminEmail Email, @adminPassword Password)
as
begin
	if not exists(select AdminEmail,AdminPassword from TeamF.Admins where AdminEmail = @adminEmail and AdminPassword = @adminPassword)
	throw 50014, 'Email and Password not found',1
	else
	select * from TeamF.Admins
end

GO
/****** Object:  StoredProcedure [TeamF].[GetAllCustomersDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE Procedure [TeamF].[GetAllCustomersDAL]
  AS
  BEGIN
  Select * From TeamF.Customer
  End
GO
/****** Object:  StoredProcedure [TeamF].[GetAllEmployees]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[GetAllEmployees]
as 
begin
	select EmployeeID,
	EmployeeName ,
	EmployeeEmail,
	Mobile ,
	CreationDateTime ,
	LastModifiedDateTime 
	from TeamF.Employees
end

GO
/****** Object:  StoredProcedure [TeamF].[GetAllTransactions]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[GetAllTransactions]
as
begin
select * from Transactions
end
GO
/****** Object:  StoredProcedure [TeamF].[getCarLoanByCustomerID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getCarLoanByCustomerID] (@customerID uniqueidentifier)
as			
begin
	if(exists (select * from TeamF.CarLoan where CustomerID=@customerID) )
		begin
			select  *
			from TeamF.CarLoan
			where CustomerID = @customerID
		end
	else
		throw 50000, 'Customer dont have a car loan',1
end
GO
/****** Object:  StoredProcedure [TeamF].[getCarLoanByLoanID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getCarLoanByLoanID] (@loanID uniqueidentifier)
as			
begin
	if(exists (select * from TeamF.CarLoan where LoanID=@loanID) )
		begin
			select  *
					
					
			from TeamF.CarLoan
			where LoanID = @loanID
		end
	else
		throw 50000, 'Loan ID dont exist',1
end
GO
/****** Object:  StoredProcedure [TeamF].[getCarLoanStatus]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getCarLoanStatus](@loanID uniqueidentifier)
as
begin
	if(exists (select * from TeamF.CarLoan where LoanID=@loanID))
		select LoanStatus from TeamF.CarLoan where LoanID=@loanID
	else
		throw 50000, 'LoanID dont exist', 1
end


GO
/****** Object:  StoredProcedure [TeamF].[GetCustomerByCustomerIDDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamF].[GetCustomerByCustomerIDDAL](@CustomerID uniqueidentifier)
  AS
  BEGIN
  Select * From Customers.Customer
  Where CustomerID = @CustomerID
  END
GO
/****** Object:  StoredProcedure [TeamF].[getEduLoanByCustomerID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getEduLoanByCustomerID] (@customerID uniqueidentifier)
as			
begin
	if(exists (select * from TeamF.EduLoan where CustomerID=@customerID) )
		begin
			select  *
			from TeamF.EduLoan
			where CustomerID = @customerID
		end
	else
		throw 50000, 'Customer dont have a car loan',1
end
GO
/****** Object:  StoredProcedure [TeamF].[getEduLoanByLoanID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getEduLoanByLoanID] (@loanID uniqueidentifier)
as			
begin
	if(exists (select * from TeamF.EduLoan where LoanID=@loanID) )
		begin
			select *
			from TeamF.EduLoan
			where LoanID = @loanID
		end
	else
		throw 50000, 'Loan ID dont exist',1
end
GO
/****** Object:  StoredProcedure [TeamF].[getEduLoanStatus]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getEduLoanStatus](@loanID uniqueidentifier)
as
begin
	if(exists (select * from TeamF.EduLoan where LoanID=@loanID))
		select LoanStatus from TeamF.EduLoan where LoanID=@loanID
	else
		throw 50000, 'LoanID dont exist', 1
end
GO
/****** Object:  StoredProcedure [TeamF].[GetEmployeeByEmail]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[GetEmployeeByEmail](@empemail Email)
as
begin
	if @empemail =''
	throw 50004, 'Employee Email cannot be blank',1
	if not exists (select EmployeeEmail from TeamF.Employees where EmployeeEmail = @empemail)
	throw 50004, 'Employee Email not found',1
	else
	begin
	select * into TeamF.#temporary from TeamF.Employees
	alter table TeamF.#temporary drop column EmployeePassword
	select * from TeamF.#temporary where EmployeeEmail = @empemail
	drop table TeamF.#temporary
	end
end

GO
/****** Object:  StoredProcedure [TeamF].[GetEmployeeByEmailandPassword]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[GetEmployeeByEmailandPassword](@empemail dbo.Email, @emppassword dbo.Password)
as
begin
	if @empemail = '' or @emppassword = ''
	throw 50005, 'Employee Email and Password cannot be blank', 1
	if not exists (select EmployeeEmail, EmployeePassword from TeamF.Employees where EmployeeEmail = @empemail and EmployeePassword = @emppassword)
	throw 50005, 'Employee Email and Password not found',1
	else
	select EmployeeID, EmployeeName, EmployeeEmail, Mobile, CreationDateTime, LastModifiedDateTime,IsActive from TeamF.Employees where EmployeeEmail = @empemail and EmployeePassword = @emppassword
end

GO
/****** Object:  StoredProcedure [TeamF].[GetEmployeeByEmployeeID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[GetEmployeeByEmployeeID](@empid uniqueidentifier)
as
begin
	if not exists(select EmployeeID from TeamF.Employees where EmployeeID = @empid)
	throw 50002, 'Employee ID not found',1
	else
	--begin
	--select * into TeamF.#temporary from TeamF.Employees
	--alter table TeamF.#temporary drop column EmployeePassword
	--select * from TeamF.#temporary where EmployeeID = @empid
	--drop table TeamF.#temporary
	--end

	select * from TeamF.Employees where EmployeeID = @empid  
end

GO
/****** Object:  StoredProcedure [TeamF].[GetEmployeeEmailandPassword]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[GetEmployeeEmailandPassword](@empemail Email, @emppassword Password)
as
begin
	if @empemail = '' or @emppassword = ''
	throw 50005, 'Employee Email and Password cannot be blank', 1
	if not exists (select EmployeeEmail, EmployeePassword from TeamF.Employees where EmployeeEmail = @empemail and EmployeePassword = @emppassword)
	throw 50005, 'Employee Email and Password not found',1
	else
	select EmployeeEmail, EmployeePassword from TeamF.Employees where EmployeeEmail = @empemail and EmployeePassword = @emppassword
end

GO
/****** Object:  StoredProcedure [TeamF].[GetEmployeesByName]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[GetEmployeesByName](@empname varchar(40))
as
begin
	if @empname = ''
	throw 50003, 'Employee Name cannot be blank',1
	if not exists (select EmployeeName from TeamF.Employees where EmployeeName = @empname)
	throw 50003, 'Employee Name not found',1
	else
	begin
	select * into TeamF.#temporary from TeamF.Employees
	alter table TeamF.#temporary drop column EmployeePassword
	select * from TeamF.#temporary where EmployeeName = @empname
	drop table TeamF.#temporary
	end

end

GO
/****** Object:  StoredProcedure [TeamF].[GetFixedDepositByAccountID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[GetFixedDepositByAccountID](@AccountID uniqueidentifier)
as 
begin

select * from TeamF.FixedDeposit where AccountID = @AccountID and IsActive=1;

end
GO
/****** Object:  StoredProcedure [TeamF].[GetFixedDepositByCustomerID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[GetFixedDepositByCustomerID](@CustomerID uniqueidentifier)
as 
begin

select * from TeamF.FixedDeposit where CustomerID = @CustomerID and IsActive=1;

end
GO
/****** Object:  StoredProcedure [TeamF].[getHomeLoanByCustomerID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getHomeLoanByCustomerID] (@customerID uniqueidentifier
											)
as			
begin
	if(exists (select * from TeamF.HomeLoan where CustomerID=@customerID) )
		begin
			select  *
			from TeamF.HomeLoan
			where CustomerID = @customerID
		end
	else
		throw 50000, 'Customer dont have a home loan',1
end
GO
/****** Object:  StoredProcedure [TeamF].[getHomeLoanByLoanID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getHomeLoanByLoanID] (@loanID uniqueidentifier)
as			
begin
	if(exists (select * from TeamF.HomeLoan where LoanID=@loanID) )
		begin
			select *
			from TeamF.HomeLoan
			where LoanID = @loanID
		end
	else
		throw 50000, 'Loan ID dont exist',1
end
GO
/****** Object:  StoredProcedure [TeamF].[getHomeLoanStatus]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamF].[getHomeLoanStatus](@loanID uniqueidentifier)
as
begin
	if(exists (select * from TeamF.HomeLoan where LoanID=@loanID))
		select LoanStatus from TeamF.HomeLoan where LoanID=@loanID
	else
		throw 50000, 'LoanID dont exist', 1
end
GO
/****** Object:  StoredProcedure [TeamF].[GetTransactionsByAccountID]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[GetTransactionsByAccountID](@accountID uniqueidentifier)
as
begin
	--if  @accountID = ''		
	--	throw 500000,'The ID is not in correct format',1;

	--else
		select * from TeamF.Transactions where AccountID = @accountID
end
GO
/****** Object:  StoredProcedure [TeamF].[RemoveCustomerDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure   [TeamF].[RemoveCustomerDAL](@CustomerID uniqueidentifier )
  AS
  Begin
  Delete Customer From Customers.Customer
  Where CustomerID = @CustomerID
  END
GO
/****** Object:  StoredProcedure [TeamF].[StoreTransactionRecords]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[StoreTransactionRecords](@accountID uniqueidentifier, @type varchar(6), @amount money, @mode varchar(14), @chequeNumber char(6))
as
begin
	declare @dateofTransaction datetime = SYSDATETIME()
	declare @transactionID uniqueidentifier = newid()
	 
	
	if @amount < 0 or @amount > 50000
			throw 500000,'Enter Correct amount',1;
	if len(ISNULL(@chequeNumber,''))<>6
			throw 500000,'Enter Correct cheque',1;

 begin try
 insert into TeamF.Transactions( TransactionID, AccountID, TypeOfTransaction, Amount, DateOfTransaction,
  Mode, ChequeNumber)
 
 values (@transactionID, @accountID, @type, @amount,  @dateofTransaction ,
            @mode, @chequeNumber )
 end try
 begin catch
	throw;
 end catch
end
GO
/****** Object:  StoredProcedure [TeamF].[UpdateAdminEmail]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamF].[UpdateAdminEmail](@adminID uniqueidentifier, @adminEmail Email)
as
begin
	if isnull(@adminID,'')=''
	throw 50012, 'Admin ID is invalid', 1
	if not exists(select AdminID from TeamF.Admins where AdminID = @adminID)
	throw 50012, 'Admin ID not found',1
	if exists(select AdminEmail from TeamF.Admins where AdminEmail = @adminEmail)
	throw 50012, 'Email already exists', 1
	else
	update TeamF.Admins set AdminEmail = @adminEmail where AdminID = @adminID
end

GO
/****** Object:  StoredProcedure [TeamF].[UpdateAdminNameAndEmail]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[UpdateAdminNameAndEmail](@adminID uniqueidentifier, @adminName varchar(40), @adminEmail Email)
as
begin
	--if isnull(@adminID,'')=''
	--throw 50012, 'Admin ID is invalid', 1
	if not exists(select AdminID from TeamF.Admins where AdminID = @adminID)
	throw 50012, 'Admin ID not found',1
	if exists(select AdminEmail from TeamF.Admins where AdminEmail = @adminEmail)
	throw 50012, 'Email already exists', 1
	else
	update TeamF.Admins set AdminEmail = @adminEmail,AdminName = @adminName,LastModifiedDateTime = GETDATE() where AdminID = @adminID
end

GO
/****** Object:  StoredProcedure [TeamF].[UpdateAdminPassword]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[UpdateAdminPassword](@adminID uniqueidentifier, @adminPassword Password)
as
begin
	--if isnull(@adminID,'')=''
	--throw 50013, 'Admin ID is invalid', 1
	if not exists(select AdminID from TeamF.Admins where AdminID = @adminID)
	throw 50013, 'Admin ID not found',1
	if exists(select AdminPassword from TeamF.Admins where AdminPassword = @adminPassword)
	throw 50012, 'Password already exists', 1
	else
	update TeamF.Admins set AdminPassword = @adminPassword where AdminID = @adminID
end

GO
/****** Object:  StoredProcedure [TeamF].[UpdateAllEmployeeDetails]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[UpdateAllEmployeeDetails](@empid uniqueidentifier, @empname varchar(40), @empemail Email, @empmobile char(10))
as
begin
	--if isnull(@empid,'')=''
	--throw 50006, 'Employee ID is invalid', 1
	if not exists(select EmployeeID from TeamF.Employees where EmployeeID = @empid)
	throw 50006, 'Employee ID not found',1
	if @empname = '' or @empemail =''  or @empmobile =''
	throw 50006, 'Employee Name, Email and Mobile should be valid', 1
	if exists (select EmployeeEmail from TeamF.Employees where EmployeeEmail = @empemail)
	throw 50006, 'Email already exists',1
	if exists (select Mobile from TeamF.Employees where Mobile = @empmobile)
	throw 50006, 'Mobile number already exists',1
	else
	update TeamF.Employees set EmployeeName = @empname, EmployeeEmail = @empemail, Mobile = @empmobile, LastModifiedDateTime = SYSDATETIME() where EmployeeID = @empid
end

GO
/****** Object:  StoredProcedure [TeamF].[UpdateCustomerByCustomerIDDAL]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamF].[UpdateCustomerByCustomerIDDAL](@CustomerID uniqueidentifier,@CustomerName varchar(40),@CustomerAddress varchar(100),@CustomerMobile char(10),@CustomerEmail varchar(40),@CustomerPan char(10),@CustomerAadhaarNumber char(12),@DOB datetime,@CustomerGender varchar(12))
  AS
  BEGIN
  Update TeamF.Customers
  Set CustomerName=@CustomerName,CustomerAddress=@CustomerAddress,CustomerMobile=@CustomerMobile,CustomerEmail=@CustomerEmail,CustomerPan=@CustomerPan,CustomerAadhaarNumber=@CustomerAadhaarNumber,DOB=@DOB,CustomerGender=@CustomerGender
  Where CustomerID =@CustomerID
  END
GO
/****** Object:  StoredProcedure [TeamF].[UpdateEmployeeEmail]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[UpdateEmployeeEmail](@empid uniqueidentifier, @empemail Email)
as
begin
	--if isnull(@empid,'')=''
	--throw 50008, 'Employee ID is invalid', 1
	if not exists(select EmployeeID from TeamF.Employees where EmployeeID = @empid)
	throw 50008, 'Employee ID not found',1
	if @empemail = '' or @empemail is null
	throw 50008, 'Employee Email cannot be null or blank', 1
	if exists(select EmployeeEmail from TeamF.Employees where EmployeeEmail = @empemail)
	throw 50008, 'Email already exists', 1
	else
	update TeamF.Employees set EmployeeEmail = @empemail, LastModifiedDateTime = SYSDATETIME() where EmployeeID = @empid
end

GO
/****** Object:  StoredProcedure [TeamF].[UpdateEmployeeMobile]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[UpdateEmployeeMobile](@empid uniqueidentifier, @empmobile char(10))
as
begin
	--if isnull(@empid,'')=''
	--throw 50010, 'Employee ID is invalid', 1
	if not exists(select EmployeeID from TeamF.Employees where EmployeeID = @empid)
	throw 50010, 'Employee ID not found',1
	if @empmobile is null or @empmobile = ''
	throw 50010, 'Employee Mobile cannot be null', 1
	if exists(select Mobile from TeamF.Employees where Mobile = @empmobile)
	throw 50010, 'Mobile Number already exists',1
	else
	update TeamF.Employees set Mobile = @empmobile, LastModifiedDateTime = SYSDATETIME() where EmployeeID = @empid
end

GO
/****** Object:  StoredProcedure [TeamF].[UpdateEmployeeName]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[UpdateEmployeeName](@empid uniqueidentifier, @empname varchar(40))
as
begin
	--if isnull(@empid,'')=''
	--throw 50007, 'Employee ID is invalid', 1
	if not exists(select EmployeeID from TeamF.Employees where EmployeeID = @empid)
	throw 50007, 'Employee ID not found',1
	if @empname = ''
	throw 50007, 'Employee Name cannot be blank', 1
	else
	update TeamF.Employees set EmployeeName = @empname, LastModifiedDateTime = SYSDATETIME() where EmployeeID = @empid
end

GO
/****** Object:  StoredProcedure [TeamF].[UpdateEmployeePassword]    Script Date: 06-11-2019 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamF].[UpdateEmployeePassword](@empid uniqueidentifier, @emppassword Password)
as
begin
	--if isnull(@empid,'')=''
	--throw 50009, 'Employee ID is invalid', 1
	if not exists(select EmployeeID from TeamF.Employees where EmployeeID = @empid)
	throw 50009, 'Employee ID not found',1
	if @emppassword is null or @emppassword = '' 
	throw 50009, 'Employee Password cannot be null or blank', 1
	else
	if exists (select EmployeePassword from TeamF.Employees where EmployeePassword = @emppassword)
	throw 50009, 'Password already exists', 1
	update TeamF.Employees set EmployeePassword = @emppassword, LastModifiedDateTime = SYSDATETIME() where EmployeeID = @empid
end

GO
