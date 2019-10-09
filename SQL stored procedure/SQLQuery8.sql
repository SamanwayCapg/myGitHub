

declare @systemDate as datetime = getdate();

use Pecunia
exec applyHomeLoan 	'y9896d7b-b12h-42f3-9b47-78ed29ac147f',
				'9a38a0e2-3745-4a09-ab6f-04ffe157e009',
				1400000,
				10.65,
				7859.258,
				85,
				@systemDate,
				'APPLIED',
							
				'SERVICE',
				8,
				85628.2,
				8500.25
with recompile


use Pecunia
select * from Loans.HomeLoan

alter table Loans.HomeLoan
alter column InterestRate money

use Pecunia
exec approveHomeLoan 'f1386d7b-a12b-42f3-9b47-60ed29ac147f', 'PROCESSING' with recompile

select * from Customers