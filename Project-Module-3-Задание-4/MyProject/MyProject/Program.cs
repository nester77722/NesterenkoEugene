using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Address> addresses = new List<Address>
            {
                new Address { Id = 1582, Country = "USA", City = "New York", State = "New York", AddressLine = "123 Broadway Street", ZipCode = "10804" },
                new Address { Id = 1580, Country = "USA", City = "New York", State = "New York", AddressLine = "5 Avenue", ZipCode = "10801" },
                new Address { Id = 1381, Country = "USA", City = "Malibu", State = "California", AddressLine = "Carbon Mesa Road, 25455", ZipCode = "90265" },
                new Address { Id = 9421, Country = "Asgard", City = "Asgard", State = "Not stated", AddressLine = "Main Castle, 93 floor", ZipCode = "Not stated" },
                new Address { Id = 2789, Country = "Norway", City = "NewAsgard", State = "Vestfold", AddressLine = "Farmannsveien, 40", ZipCode = "3125" },
                new Address { Id = 1576, Country = "USA", City = "New York", State = "New York", AddressLine = "42 St. Mark’s Place, Apt. 21", ZipCode = "10841" },
                new Address { Id = 7120, Country = "USSR", City = "Volgograd", State = "Volgograd Oblast", AddressLine = "Cosmonauts street, 35", ZipCode = "10841" }
            };

            List<Person> people = new List<Person>
            {
                new Person { Age = DateTime.Now.Year - 1970, Email = "IronMan@Avengers.com", FirstName = "Anthony", LastName = "Stark", Id = 1, AddressList = new List<int> { 1582, 1381 } },
                new Person { Age = 1500, Email = "Thor@Avengers.com", FirstName = "Thor", LastName = "Odinson", Id = 2, AddressList = new List<int> { 1582, 2789, 9421 } },
                new Person { Age = DateTime.Now.Year - 1918, Email = "Captain@Avengers.com", FirstName = "Steve", LastName = "Rogers", Id = 3, AddressList = new List<int> { 1582, 1576 } },
                new Person { Age = DateTime.Now.Year - 1984, Email = "BlackWidow@Avengers.com", FirstName = "Natalia", LastName = "Romanoff", Id = 4, AddressList = new List<int> { 1582, 7120 } },
                new Person { Age = DateTime.Now.Year - 2005, Email = "SpiderMan@Avengers.com", FirstName = "Peter", LastName = "Parker", Id = 5, AddressList = new List<int> { 1582, 1580 } }
            };

            var result = from p in people
                         select new
                         {
                             Email = p.Email,
                             Name = p.FirstName + " " + p.LastName,
                             Age = p.Age,
                             Address = from ad in addresses
                                       from adId in p.AddressList
                                       where ad.Id == adId
                                       select new
                                       {
                                           City = ad.City,
                                           Country = ad.Country,
                                           State = ad.State,
                                           AddressLine = ad.AddressLine
                                       }
                         };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} {item.Email} is {item.Age} years old and lived in: ");
                foreach (var address in item.Address)
                {
                    Console.WriteLine($"{address.Country} {address.City} {address.State} {address.AddressLine}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            var lessThan18 = from p in people
                             where p.Age > 18
                             select p;

            Console.WriteLine("More than 18");
            foreach (var item in lessThan18)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine();

            var countries = (from address in addresses
                             select address.Country).Distinct();

            var countryGroups = from country in countries
                                select new
                                {
                                    Country = country,
                                    People = (from p in result
                                              from address in p.Address
                                              where address.Country == country
                                              select p).Distinct()
                                };

            Console.WriteLine();

            foreach (var g in countryGroups)
            {
                Console.WriteLine($"People who lived in {g.Country}:");
                foreach (var t in g.People)
                {
                    Console.WriteLine(t.Name);
                }

                Console.WriteLine();
            }

            Console.WriteLine((from person in people
                              select person.Age).Average());
        }
    }
}
