using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookStoreController : ControllerBase
    {
        private readonly IDataService _dataService;

        public BookStoreController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IEnumerable<BookStore> GetAll()
        {
            return _dataService.GetAllStores();
        }

        [HttpGet]
        [Route("[[id]]")]
        public BookStore GetBookStore(int id)
        {
            return _dataService.GetStoreById(id);
        }

        [HttpPost]
        public void Post([FromBody] BookStore bookStore)
        {
            if (bookStore is null)
            {
                throw new Exception("Input is null");
            }

            _dataService.AddBookStore(bookStore);
        }

        [HttpPut]
        public void Update(BookStore bookStore)
        {
            if (bookStore is null)
            {
                throw new Exception("Input is null");
            }

            _dataService.UpdateBookStore(bookStore);
        }

        [HttpDelete]
        [Route("[[id]]")]
        public void Delete(int id)
        {
            _dataService.RemoveBookStore(id);
        }
    }
}
