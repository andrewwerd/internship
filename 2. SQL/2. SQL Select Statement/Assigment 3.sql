SELECT
	[Customer Name], pack_id as [Package Id], speed as [Internet Speed], monthly_payment as [Monthly Payment], [Sector Name] 
from packages
inner join
	(
	select 
	sector_id as SectorId, sector_name as [Sector Name]
	from sectors
	where sector_name = 'Business'
	) as Sector
On packages.sector_id = Sector.SectorId
inner join
	(
	select 
	(First_Name + ' '+  Last_Name) as [Customer Name], pack_id as PakcageId
	from customers
	)as Customer
On Customer.PakcageId = packages.pack_id