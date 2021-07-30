using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IDataService _dataService;

        public BookController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _dataService.GetAllBooks();
        }

        [HttpGet]
        [Route("[[id]]")]
        public Book GetBook(int id)
        {
            return _dataService.GetBookById(id);
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            if (book is null)
            {
                throw new Exception("Input is null");
            }

            _dataService.AddBook(book);
        }

        [HttpPut]
        public void Update(Book book)
        {
            if (book is null)
            {
                throw new Exception("Input is null");
            }

            _dataService.UpdateBook(book);
        }

        [HttpDelete]
        [Route("[[id]]")]
        public void Delete(int id)
        {
            _dataService.RemoveBook(id);
        }
    }
}
