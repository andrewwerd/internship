--create table FavoritePartners(
--Id int primary key identity(1,1),
--CustomerId int,
--PartnerId int
--foreign key (CustomerId) references Customers(Id),
--foreign key (PartnerId) references Partners(Id)
--)

--go

--Create TABLE PremiumCustomers(
--Id int primary key identity(1,1),
--CustomerId int,
--PartnerId int,
--foreign key (CustomerId) references Customers(Id),
--foreign key (PartnerId) references Partners(Id)
--)

--go


--alter table Customers
--add IsPremium int default 0 check (IsPremiun = 0 or IsPremium = 1)
--alter table Customers
--add UserId int unique
--alter table Customers
--add foreign key (UserId) references [Users](Id)

--go

--alter table Partners
--add UserId int unique
--alter table Customers
--add foreign key (UserId) references [Users](Id)

--go

alter table Rewiews
add AnswerRewiew int unique default null
alter table Rewiews
add foreign key (AnswerRewiew) references Rewiews(Id)

go 

alter table Customers
alter column UserId int not null

alter table Partners
alter column UserId int not null