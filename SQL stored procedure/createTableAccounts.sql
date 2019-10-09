use Pecunia
go
create schema Accounts

Create Table Accounts.Account
(
AccountID varchar(40),
AccountNumber bigint,
HomeBranch varchar(20),
Balance Money,
Feedback varchar,
IsActive bit,
DateOfCreation DateTime ,
AccountType varchar(7),
CustomerID varchar(40),
AccountBalance money,
FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)
Go
--Creating Table FixedDeposit
Create Table Accounts.FixedDeposit
(
AccountID varchar(40),
FdDeposit bigint,
InterestRate float,
Tenure int ,
AccountNumber bigint,
HomeBranch varchar(20),
CustomerID varchar(40),
FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
Feedback varchar,
IsActive bit,
DateOfCreation DateTime 
)