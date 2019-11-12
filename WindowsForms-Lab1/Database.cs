using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab1
{
    public class Database
    {
        public List<Book> books = new List<Book>();

        public event Action<Book> AddBookEvent;
        public event Action<Book> EditBookEvent;
        public event Action<Book> DeleteBookEvent;

        public void addBook(Book book) 
        {
            books.Add(book);

            AddBookEvent?.Invoke(book);
        }
        public void updateBook(Book book)
        {
            EditBookEvent?.Invoke(book);
        }
        public void deleteBook(Book book)
        {
            books.Remove(book);

            DeleteBookEvent?.Invoke(book);
        }
    }
}
