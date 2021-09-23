using Customers.Api.Models;
using System.Collections.Generic;

namespace Customers.Api.Interfaces
{
    public interface ICustomerService
    {
        IReadOnlyCollection<Customer> GetAll();
        Customer GetById(int id);
        void Create(Customer customer);
        void Delete(int id);
        void Update(Customer customer);
    }
}
