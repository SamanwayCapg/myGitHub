create database Pecunia

use Pecunia
go
create schema Loans


create table Customers(
	CustomerID varchar(40)
		primary key
);


use Pecunia
go
create table Loans.EduLoan(
	LoanID varchar(40),
	CustomerID varchar(40) foreign key references Customers(CustomerID)
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


use Pecunia
go
create table Loans.CarLoan(
	LoanID varchar(40),
	CustomerID varchar(40) foreign key references Customers(CustomerID)
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


use Pecunia
go
create table Loans.HomeLoan(
	LoanID varchar(40),
	CustomerID varchar(40) foreign key references Customers(CustomerID)
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

alter table Loans.EduLoan
alter column
	LoanID varchar(40) not null

alter table Loans.EduLoan
add primary key (LoanID)