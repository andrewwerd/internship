if OBJECT_ID('OrderInfo','U') is not null
drop table OrderInfo

create table OrderInfo(
Id int primary key identity,
OrderId int not null,
ProductId int not null,
CustomerId int,
ProductName nvarchar(50) not null,
UnitPrice decimal(12,2) not null,
Quantity int not null,
OriginCountry nvarchar(40)null
)


INSERT INTO OrderInfo (OrderId, ProductId, UnitPrice, Quantity, ProductName)
Output inserted.OrderId,Inserted.ProductId,inserted.UnitPrice,inserted.ProductName, inserted.Quantity
SELECT OrderId, ProductId, UnitPrice, Quantity, (select ProductName from Product where id=OrderItem.ProductId)
FROM   OrderItem


UPDATE OrderInfo
  SET OriginCountry = Country
FROM Product AS P 
  INNER JOIN Supplier AS S
    ON P.SupplierId = S.Id 
WHERE P.Id = ProductId;


go 

UPDATE OrderInfo
  SET OrderInfo.CustomerId = [Order].CustomerId
FROM [Order] 
WHERE OrderId = [Order].Id;

go

with test_uu(Country,InCountry,OutCountry) as
(
select t1.Country, Sum(InCountry) as InCountry, sum(OutCountry) as OutCountry
from
(
	select 
		Country, 
		(select Count(OriginCountry) from OrderInfo where OriginCountry = Customer.Country and CustomerId = Customer.Id)as InCountry, 
		(select Count(OriginCountry) from OrderInfo where OriginCountry != Customer.Country and CustomerId = Customer.Id) as OutCountry 
	from Customer
) t1 
group by Country
)



select Country, InCountry, OutCountry from test_uu
where OutCountry > ( select Avg(OutCountry) from test_uu)

select Country, Sum(InCountry) as InCountry, sum(OutCountry) as OutCountry
from
(
	select 
		Country, 
		(select Count(OriginCountry) from OrderInfo where OriginCountry = Customer.Country and CustomerId = Customer.Id)as InCountry, 
		(select Count(OriginCountry) from OrderInfo where OriginCountry != Customer.Country and CustomerId = Customer.Id) as OutCountry 
	from Customer
) as table1
Group by Country
having sum(OutCountry) >  (
							select Avg(OutCountry)	
							from
							(
									select Country, Sum(InCountry) as InCountry, sum(OutCountry) as OutCountry
									from
									(
										select 
											Country, 
											(select Count(OriginCountry) from OrderInfo where OriginCountry = Customer.Country and CustomerId = Customer.Id)as InCountry, 
											(select Count(OriginCountry) from OrderInfo where OriginCountry != Customer.Country and CustomerId = Customer.Id) as OutCountry 
										from Customer
									) as table1
									Group by Country
							 )as table2
							)

go
 
truncate table OrderInfo

go

DELETE O
FROM   OrderInfo AS O
       INNER JOIN
       Customer AS C
       ON O.CustomerId = C.Id
WHERE  C.country = N'USA';

go

MERGE INTO OrderInfo as O
USING (
	SELECT Country, Product.Id as PId FROM Product
	  INNER JOIN Supplier
		ON Product.SupplierId = Supplier.Id 
	)as P ON O.ProductId = P.PId

WHEN MATCHED and o.OriginCountry is null THEN UPDATE 
    SET O.OriginCountry = P.Country;

