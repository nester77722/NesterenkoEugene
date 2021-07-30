using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api
{
    public interface IDataService
    {
        public void AddBook(Book book);
        public void AddBookStore(BookStore bookStore);
        public IEnumerable<BookStore> GetAllStores();
        public IEnumerable<Book> GetAllBooks();
        public BookStore GetStoreById(int id);
        public Book GetBookById(int id);
        public bool RemoveBookStore(int id);
        public bool RemoveBook(int id);
        public bool UpdateBook(Book book);
        public bool UpdateBookStore(BookStore bookrStore);
    }
}
