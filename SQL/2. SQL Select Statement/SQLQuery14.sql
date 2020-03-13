select*from
(
	select 
	(FirstName+' '+LastName) as Customer,
	Country,
	(
		select SUM(TotalAmount) as total from [Order]
		where CustomerId = Customer.Id
	) 
	as Amount,
	( 
		select Count(OrderNumber) from [Order] 
		where CustomerId = Customer.Id
	)as NumberOfOrders
	from Customer
) as table1
where Amount is not null
order by Country

go

select Country, Sum(NumberOfOrders) as NumberOfOrdersfrom, SUM(Amount) as Amount
from
(
	select 
	Country,
	(
		select SUM(TotalAmount) as total from [Order]
		where CustomerId = Customer.Id
	) 
	as Amount,
	( 
		select Count(OrderNumber) from [Order] 
		where CustomerId = Customer.Id
	)as NumberOfOrders
	from Customer
) as table1
group by Country

go

select 
	Country,
	Count(OrderNumber) as NumberOfOrders,
	Sum(TotalAmount) as Amount
from Customer
inner join (select CustomerId, OrderNumber, TotalAmount from [Order])as OrderInfo
on Customer.Id = OrderInfo.CustomerId
group by Country

go 

select 
	(FirstName+' '+LastName) as Customer,
	Country
from Customer
left join (select CustomerId from [Order])as OrderInfo
on Customer.Id = OrderInfo.CustomerId
where OrderInfo.CustomerId is null

go

