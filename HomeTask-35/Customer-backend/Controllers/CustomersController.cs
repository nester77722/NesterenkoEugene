using Customers.Api.Interfaces;
using Customers.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetAll();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }
    }
}
