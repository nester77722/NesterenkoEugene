using Customers.Api.Interfaces;
using Customers.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Customers.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _data;
        private int _innerId;

        public CustomerService()
        {
            _innerId = 1;
            _data = new List<Customer>()
            {
                new Customer{Id = _innerId++, FirstName = "Carlos", LastName = "Solis" ,RoleId = 1},
                new Customer{Id = _innerId++, FirstName = "Ihor", LastName = "Serdiuk" ,RoleId = 2},
                new Customer{Id = _innerId++, FirstName = "Gennadiy", LastName = "Kernes" ,RoleId = 1},
            };
        }

        public void Create(Customer customer)
        {
            _data.Add(customer);
        }

        public void Delete(int id)
        {
            var customerToDelete = _data.First(x => x.Id == id);
            _data.Remove(customerToDelete);
        }

        public IReadOnlyCollection<Customer> GetAll()
        {
            return _data;
        }

        public Customer GetById(int id)
        {
            return _data.First(x => x.Id == id);
        }

        public void Update(Customer customer)
        {
            var customerToUpdate = _data.First(x => x.Id == customer.Id);

            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.FirstName = customer.LastName;
            customerToUpdate.RoleId = customer.RoleId;
        }
    }
}
