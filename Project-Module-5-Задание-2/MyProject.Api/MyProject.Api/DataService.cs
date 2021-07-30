using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api
{
    public class DataService : IDataService
    {
        public DataService()
        {
            BookStores = new List<BookStore>();
            Books = new List<Book>();
            var random = new Random();
            Books.AddRange(new List<Book>
            {
                new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", Author = "J. K. Rowling", PagesAmount = 352, Price = 304},
                new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", Author = "J. K. Rowling", PagesAmount = 384, Price = 304},
                new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", Author = "J. K. Rowling", PagesAmount = 480, Price = 304},
                new Book { Id = 4, Name = "Potter and the Goblet of Fire", Author = "J. K. Rowling", PagesAmount = 640, Price = 342},
                new Book { Id = 5, Name = "Harry Potter and the Order of the Phoenix", Author = "J. K. Rowling", PagesAmount = 816, Price = 342},
            });

            BookStores.AddRange(new List<BookStore>
            {
                new BookStore { Id = 1, Name = "BritishBook", Address = "Kharkiv", Books = Books},
                new BookStore { Id = 2, Name = "Powells", Address = "Kiev", Books = Books},
            }) ;
        }

        public List<Book> Books { get; }
        public List<BookStore> BookStores { get; }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void AddBookStore(BookStore bookStore)
        {
            BookStores.Add(bookStore);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }

        public IEnumerable<BookStore> GetAllStores()
        {
            return BookStores;
        }

        public Book GetBookById(int id)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Id == id)
                {
                    return Books[i];
                }
            }

            throw new Exception("Book with such id does not exist");
        }

        public BookStore GetStoreById(int id)
        {
            for (int i = 0; i < BookStores.Count; i++)
            {
                if (BookStores[i].Id == id)
                {
                    return BookStores[i];
                }
            }

            throw new Exception("Store with such id does not exist");
        }

        public bool RemoveBook(int id)
        {
            return Books.Remove(Books.Select(s => s).Where(s => s.Id == id).First());
        }

        public bool RemoveBookStore(int id)
        {
            return BookStores.Remove(BookStores.Select(s => s).Where(s => s.Id == id).First());
        }

        public bool UpdateBook(Book book)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Name == book.Name)
                {
                    Books[i] = book;
                    return true;
                }
            }

            return false;
        }

        public bool UpdateBookStore(BookStore bookStore)
        {
            for (int i = 0; i < BookStores.Count; i++)
            {
                if (BookStores[i].Name == bookStore.Name)
                {
                    BookStores[i] = bookStore;
                    return true;
                }
            }

            return false;
        }
    }
}
