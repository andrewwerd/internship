select 
(First_Name+' '+Last_Name) as Name, pack_id as PackageID, [Internet Speed] 
from customers
inner join 
	(
	select speed as [Internet Speed],pack_id as PackageID 
	from packages
	 where pack_id between 22 and 27
	 ) as table1
ON customers.pack_id = table1.PackageID
Order By Last_Name asc