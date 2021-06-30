use Task4
select Users.FirstName, Users.LastName, Products.Name, Products.Price, CartItem.Count
from Users, Products, CartItem, Cart
where Users.Id = Cart.Id and CartItem.ProductId = Products.Id