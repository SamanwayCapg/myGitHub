use  Pecunia
go

use Pecunia
go
use Pecunia
create schema Pecunia

/*TABLES*/
--creating table for Customers
Create Table Pecunia.Customers
(
  CustomerID uniqueidentifier Primary Key,
  CustomerName varchar(40) NOT NULL,
  CustomerAddress varchar(200),
  CustomerMobile char(10) NOT NULL,
  CustomerEmail varchar(40),
  CustomerPan char(10),
  CustomerAadhaarNumber char(12),
  DOB datetime,
  CustomerGender varchar(12)
);

use Pecunia
go

--creating type
create type Email from varchar(40)
go

--creating type
create type Password from varchar(15)
go

USE Pecunia
go


/*TABLES*/
--creating table for Admins
create table Pecunia.Admins
(
	AdminID uniqueidentifier primary key,
	AdminName varchar(40) not null,
	AdminEmail Email not null,
	AdminPassword Password not null,
	CreationDateTime datetime,
	LastModifiedDateTime datetime,
	IsActive bit,
	EmployeeID uniqueidentifier foreign key (EmployeeID) references Pecunia.Employees(EmployeeID)
);

USE Pecunia
go

--creating table for Employees
create table Pecunia.Employees
(
	EmployeeID uniqueidentifier primary key,
	EmployeeName varchar(40) not null,
	EmployeeEmail Email not null,
	EmployeePassword Password not null,
	Mobile char(10),
	CreationDateTime datetime,
	LastModifiedDateTime datetime,
	IsActive bit
);

USE Pecunia
go

--creating table for Education Loan
create table Pecunia.EduLoan
(
	LoanID uniqueidentifier primary key,
	CustomerID uniqueidentifier foreign key references Pecunia.Customers(CustomerID)
	on delete no action
	on update cascade,
	AmountApplied money,
	InterestRate decimal,
	EMI_amount money,
	RepaymentPeriod tinyint,
	DateOfApplication datetime,
	LoanStatus varchar(15),
	Course varchar(15),

	InstituteName varchar(50),
	StudentID varchar(20),
	RepaymentHoliday tinyint
);

--creating table for Car Loan
use Pecunia
go

create table Pecunia.CarLoan(
	LoanID uniqueidentifier primary key,
	CustomerID uniqueidentifier foreign key references Pecunia.Customers(CustomerID)
	on delete no action
	on update cascade,
	AmountApplied money,
	InterestRate decimal,
	EMI_amount money,
	RepaymentPeriod tinyint,
	DateOfApplication datetime,
	LoanStatus varchar(15),
	Course varchar(15),

	Occupation varchar(15),
	GrossIncome money,
	SalaryDeduction money,
	VehicleType varchar(15)
);

--creating table for Car Loan
use Pecunia
go

create table Pecunia.HomeLoan(
	LoanID uniqueidentifier primary key,
	CustomerID uniqueidentifier foreign key references Pecunia.Customers(CustomerID)
	on delete no action
	on update cascade,
	AmountApplied money,
	InterestRate decimal,
	EMI_amount money,
	RepaymentPeriod tinyint,
	DateOfApplication datetime,
	LoanStatus varchar(15),
	Course varchar(15),

	Occupation varchar(15),
	ServiceYears tinyint,
	GrossIncome money,
	SalaryDeduction money
);

--creating table for Accounts
use Pecunia
go

Create Table Pecunia.Account
(
AccountID uniqueidentifier primary key,
AccountNumber bigint,
HomeBranch varchar(20),
Balance Money,
Feedback varchar,
IsActive bit,
DateOfCreation DateTime ,
AccountType varchar(7),
AccountBalance money,
CustomerID uniqueidentifier foreign key references Pecunia.Customers(CustomerID)
)

use Pecunia
go

--creating table for FixedDeposit
Create Table Pecunia.FixedDeposit
(
AccountID uniqueidentifier primary key,
FdDeposit bigint,
InterestRate float,
Tenure int ,
AccountNumber bigint,
HomeBranch uniqueidentifier,
CustomerID uniqueidentifier foreign key references Pecunia.Customers(CustomerID),
Feedback varchar,
IsActive bit,
DateOfCreation DateTime 
);

use Pecunia
go

--creating table for Transactions
create table Pecunia.Transactions
(
TransactionID uniqueidentifier primary key,
AccountNumber bigint NOT NULL,
AccountID uniqueidentifier foreign key (AccountID) references Pecunia.Account(AccountID)
on delete no action
on update cascade,
TypeOfTransaction varchar(6) NOT NULL,
Amount money NOT NULL,
DateOfTransaction DateTime,
ModeOfTransaction varchar(14) NOT NULL,
ChequeNumber char(6) NOT NULL
);