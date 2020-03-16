select Customer_Id, First_Name, Last_Name, City, [State] from customers
where [State] = (select [State] from customers where Customer_Id= 170)

go

select pack_id as PackageNumber, speed as InternetSpeed, sector_id as SectorNumber from packages
where sector_id = (select sector_id from packages where pack_id = 10)

go

select Customer_Id, First_Name, Join_Date from customers
where Join_Date > (select Join_Date from customers where Customer_Id= 540)


go

select Customer_Id, First_Name, Join_Date from customers
where Year(Join_Date) = (select Year(Join_Date) from customers where Customer_Id= 372)

go

select Customer_Id, First_Name, Last_Name, City, [State], pack_id as PackageId from customers
where (select speed from packages where pack_id = customers.pack_id) = '5Mbps'

go

select pack_id as PackageNumber, speed as InternetSpeed, strt_date as StartDate from packages
where Year(strt_date) = (select Year(strt_date) from packages where pack_id= 7)

go

select Customer_Id,First_Name, monthly_discount, pack_id as PackageId, main_phone_num as MainPhone, secondary_phone_num as SecondaryPhone from customers
where (
	select 
	sector_name 
	from sectors
	inner join packages
	on sectors.sector_id = packages.sector_id
	where pack_id = customers.pack_id
	) = 'Business'

go

select Customer_Id, First_Name, monthly_discount, pack_id as PackageId from customers
where (select monthly_payment from packages where pack_id = customers.pack_id) > (select AVG(monthly_payment) from packages)

go

select First_Name, City, [State], Birth_Date, monthly_discount from customers
where Birth_Date = (select Birth_Date from customers where Customer_Id = 179)
	and monthly_discount >  (select monthly_discount from customers where Customer_Id = 107)

go

select * from packages
where speed = (select speed from packages where pack_id = 30)
	and monthly_payment > (select monthly_payment from packages where pack_id = 7)

go

select pack_id as PackageNumber, speed as InternetSpeed, monthly_payment from packages
where monthly_payment > (select max(monthly_payment)from packages where speed  = '5Mbps')

go

select pack_id as PackageNumber, speed as InternetSpeed, monthly_payment from packages
where monthly_payment > (select min(monthly_payment)from packages where speed  = '5Mbps')

go

select pack_id as PackageNumber, speed as InternetSpeed, monthly_payment from packages
where monthly_payment <(select max(monthly_payment)from packages where speed  = '5Mbps')

go

select First_Name, monthly_discount, pack_id from customers
where monthly_discount < (select avg(monthly_discount) from customers) 
and pack_id = (select pack_id from customers where First_Name = 'Kevin')


go

select First_Name from customers
where pack_id in ((select pack_id from packages where year(strt_date) between 2008 and 2010))