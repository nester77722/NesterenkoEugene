create table Categories
(
	Id int primary key IDENTITY,
	Name NVARCHAR(50)
)

create table Products
(
	Id int primary key IDENTITY,
	CategoryId int not null,
	Name NVARCHAR(50),
	Price int
	foreign key (CategoryId) references Categories(Id)
)

create table CartItem
(
	CartId int,
	ProductId int not null,
	Count int
	foreign key (ProductId) references Products(Id),
)

create table Discounts
(
	Id int primary key IDENTITY,
	Value decimal not null
)

create table Users
(
		Id int primary key IDENTITY,
		FirstName nvarchar(50) not null,
		LastName nvarchar(50) not null,
		Email nvarchar(50) unique not null,
		Age int check (Age >= 18) not null
)

create table UserAddresses
(
		Id int primary key IDENTITY,
		UserId int not null,
		foreign key (UserId) references Users(Id),
		CountryCode int,
		State nvarchar(50),
		City nvarchar(50) not null,
		Address nvarchar(50) not null,
		PhoneNumber nvarchar(50) not null
)

create table Cart
(
	Id int primary key IDENTITY,
	UserId int unique not null,
	foreign key (UserId) references Users(Id),
	DiscountId int
	foreign key (DiscountId) references Discounts(Id)
)