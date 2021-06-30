select Users.FirstName, Users.LastName, UserAddresses.City, UserAddresses.Address
from Users, UserAddresses
where Users.Id = UserAddresses.UserId