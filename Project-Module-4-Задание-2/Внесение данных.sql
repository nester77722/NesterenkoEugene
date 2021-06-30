insert into Categories (Name)
values
('Phone'),
('Notebook')

insert into Products(Name, CategoryId, Price)
values
	('Asus rog strix g 15', 2, 2500),
	('Lenovo ThinkPad P15 Gen 1', 2, 5000),
	('Samsung Galaxy A11', 1, 350)

insert into Users (FirstName, LastName, Email, Age)

values
	('Daniil', 'Babyak', 'Imperatorvkresle@gmail.com', 19),
	('Andriy', 'Melnik', 'andrewMel@gmail.com', 20)

insert into UserAddresses(UserId, City, Address, PhoneNumber)
values
	(1, 'Kharkov', 'Heroiv Pratsi 54', 380730333040),
	(1, 'Kharkov', 'Metrobudivnikiv 35', 380730333040),
	(2, 'Kharkov', 'Naukova 15', 380672477708)

insert into Discounts (value)
values
	(5),
	(10),
	(15)	

insert into Products(Name, CategoryId, Price)
values
('iPhone X', 1, 1000),
('Asus Rog Strix g15', 2, 2500)

insert into Cart (DiscountId, UserId)
values
(1,1)

insert into CartItem (CartId, ProductId, Count)
values
(1,1,1)