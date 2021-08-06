using System;
using System.Collections.Generic;

namespace UserRegistration.Api
{
    public class DataService : IDataService
    {
        public IList<User> Users { get; set; }

        public DataService()
        {
            Users = new List<User>();
        }

        public User Create(User user)
        {
            User newUser = new User { Age = user.Age, FirstName = user.FirstName, LastName = user.LastName, Id = new Random().Next(0, 1000)};
            Users.Add(newUser);
            return newUser;
        }
    }
}
