create database dbCard

go

use dbCard

create table Users(
	Id int primary key identity,
	UserName nvarchar(20) unique not null,
	[Password] nvarchar(20) not null,
	Email nvarchar(40) unique not null,
)


create table Customers(
	Id int primary key identity,
	FirstName nvarchar(40) not null,
	LastName nvarchar(40) not null,
	Age int null,
	DateOfBirth date not null,
	Gender nvarchar(10) not null,
	Foto varbinary(max) null,
	DateOfRegistration date default getdate() not null,
	IsPremium int default 0 check (IsPremium = 0 or IsPremium = 1),
	UserId int unique not null
	foreign key (UserId) references Users(Id) on delete cascade
)


create table Partners(
	Id int primary key identity,
	[Name] nvarchar(40) unique not null,
	Category nvarchar(40) default 'UNIVERSAL' not null,
	Rating decimal(2,2) default 0 not null,
	[Description] nvarchar(4000) not null,
	Logo varbinary(max) null,
	DateOfRegistration date default getdate() not null,
	UserId int unique not null
	foreign key (UserId) references Users(Id) on delete cascade
)


create table FavoritePartners(
	Id int primary key identity(1,1),
	CustomerId int not null,
	PartnerId int not null,
	foreign key (CustomerId) references Customers(Id) on delete cascade,
	foreign key (PartnerId) references Partners(Id) on delete cascade
)

create table CustomersBalance(
	Id int primary key identity(1,1),
	CustomerId int not null,
	DiscountId int not null,
	Amount decimal(10,2) default 0 not null,
	foreign key (CustomerId) references Customers(Id) on delete cascade,
)


Create TABLE PremiumCustomers(
	Id int primary key identity(1,1),
	CustomerId int not null,
	PartnerId int not null,
	foreign key (CustomerId) references Customers(Id) on delete cascade,
	foreign key (PartnerId) references Partners(Id) on delete cascade
)


create table PremiumDiscount(
	Id int primary key identity,
	PriceOfDiscount decimal(4,2) default 0 not null,
	DiscountPercent decimal(2,2) default 0 not null,
	AccumulationPercent decimal(2,2) default 0 not null,
	PartnerId int not null,
	Foreign key (PartnerId) references Partners(Id) on delete cascade
)


alter table CustomersBalance
add foreign key (DiscountId) references Discount(Id) On delete cascade


Create table StandartDiscount(
	Id int primary key identity,
	AmountOfDiscount decimal(4,2) default 0 not null,
	DiscountPercent decimal(2,2) default 0 not null,
	PartnerId int not null,
	Foreign key (PartnerId) references Partners(Id)
)

Create table BirthdayDiscount(
	Id int primary key identity,
	DiscountPercent decimal(2,2) default 0 not null,
	PartnerId int not null,
	Foreign key (PartnerId) references Partners(Id) on delete cascade
)

Create table Filials(
	Id int primary key identity,
	PartnerId int foreign key references Partners(Id) not null,
	[Address] nvarchar(40) not null,
	PhoneNumber nvarchar(15) unique not null
)
create table News(
	Id int primary key identity,
	PartnerId int foreign key references Partners(Id) not null,
	Foto varbinary(max) null,
	Title nvarchar(40) not null,
	Body nvarchar(4000) not null,
	ShortBody nvarchar(100) null,
	DateOfCreation datetime default GETDATE() not null
	)
create table Rewiews(
	Id int primary key identity,
	PartnerId int not null,
	CustomerId int null,
	Body nvarchar(1000) not null,
	NumbersOfLikes int default 0 check(NumbersOfLikes > 0) not null,
	NumbersOfDislakes int default 0 check (NumbersOfDislakes >0) not null,
	AnswerRewiew int null,
	Foreign key(AnswerRewiew) references Rewiews(Id) on delete cascade,
	Foreign key(CustomerId) references Customers(Id) on delete set null,
	Foreign key(PartnerId) references Partners(Id) on delete cascade
	)
create table TransactionHistory(
	Id int primary key identity,
	PartnerName nvarchar(40) not null,
	FilialAddress nvarchar(40) not null,
	Category nvarchar(40) not null,
	AllAmount decimal(10,2) not null,
	AmountForPay decimal(10,2) not null,
	DiscountAmount decimal(10,2) not null,
	AccumulationAmount decimal(10,2) null,
	CustomerId int not null,
	FilialId int not null,
	Foreign key (CustomerId) references Customers(Id),
	Foreign key (FilialId) references Filials(Id),
	check(AllAmount > 0),
	check(AmountForPay > 0),
	check(DiscountAmount > 0),
	check(AccumulationAmount > 0)
	)