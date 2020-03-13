SELECT
	(First_Name + ' '+  Last_Name) as [Customer Name], 
	pack_id as [Package Id],
	[Internet Speed], 
	[Monthly Payment]
from customers
inner join
	(
	select 
	pack_id as PackageId,
	speed as [Internet Speed],
	monthly_payment as [Monthly Payment]
	from packages
	)as packages
On customers.pack_id = packages.PackageId

go

SELECT
	(First_Name + ' '+  Last_Name) as [Customer Name], 
	pack_id as [Package Id],
	[Internet Speed], 
	[Monthly Payment]
from customers
left join
	(
	select 
	pack_id as PackageId,
	speed as [Internet Speed],
	monthly_payment as [Monthly Payment]
	from packages
	)as packages
On customers.pack_id = packages.PackageId

go

SELECT 
	(First_Name + ' '+  Last_Name) as [Customer Name], 
	packages.PackageId as [Package Id],
	[Internet Speed], 
	[Monthly Payment]
from customers 
right join
	(
	select 
	pack_id as PackageId,
	speed as [Internet Speed],
	monthly_payment as [Monthly Payment]
	from packages
	)as packages
On customers.pack_id = packages.PackageId
order by [Package Id]

go 

SELECT
	(First_Name + ' '+  Last_Name) as [Customer Name], 
	packages.PackageId as [Package Id],
	[Internet Speed], 
	[Monthly Payment]
from customers
full outer join
	(
	select 
	pack_id as PackageId,
	speed as [Internet Speed],
	monthly_payment as [Monthly Payment]
	from packages
	)as packages
On customers.pack_id = packages.PackageId
order by [Package Id]