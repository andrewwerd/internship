SELECT
	(First_Name + ' '+  Last_Name) as [Customer Name], 
	Join_Date as [Join Date], 
	pack_id as [Package Id], 
	[Internet Speed], [Sector Name] 
from customers
inner join
	(
	select 
	speed as [Internet Speed],
	pack_id as PackageId,
	sector_id
	from packages
	)as Package
On Package.PackageId = customers.pack_id
inner join
	(
	select 
	sector_id as SectorId, sector_name as [Sector Name]
	from sectors
	) as Sector
On Package.sector_id = Sector.SectorId
where Year(Join_Date) = 2006
order by Last_Name