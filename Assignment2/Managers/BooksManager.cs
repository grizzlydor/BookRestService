using BookLibrary;
using System.Collections.Generic;

namespace Assignment2.Managers
{
    public class BooksManager
    {
        #region BookRepository
        /// <summary>
        /// Static list of books
        /// </summary>
        private static List<Book> _books = new List<Book>()
        {
            new Book() {Title = "JavaScript and JQuery: Interactive Front-End Web Development",
                Author = "Jon Duckett", PageNumber = 645, ISBN13 = "978-1118531648"},
            new Book() {Title = "The Agile Samurai: How Agile Masters Deliver Great Software (Pragmatic Programmers)",
                Author = "Jonathan Rasmusson", PageNumber = 267 , ISBN13 = "978-1934356586"},
            new Book() {Title = "Extreme Programming Explained",
                    Author = "Kent Beck, Cynthia Andres", PageNumber = 224, ISBN13 = "978-0321278654"}
        };
        #endregion
        #region GetAll
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>(_books);
        }
        #endregion
        #region GetBookByISBN
        /// <summary>
        /// Method that gets the book by its isbn number
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public Book GetBookByISBN(string isbn)
        {
            Book book = _books.Find(b => b.ISBN13 == isbn);
                return book;
        }
        #endregion
        #region Create
        public Book Create(Book book)
        {
            _books.Add(book);
            return book;
        }
        #endregion
        #region Delete
        /// <summary>
        /// A method that firstly checks if 
        /// the book with the specified isbn 
        /// is in the list and deletes it. 
        /// Otherwise it returns a null
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public Book Delete(string isbn)
        {
            Book book = _books.Find(book => book.ISBN13 == isbn);
            if (book == null)
                return null;
            _books.Remove(book);
            return book;
        }
        #endregion
        #region Update
        public Book Update(string isbn, Book update)
        {
            var book = GetBookByISBN(isbn);
            if (book == null) return null;

            book.Title = update.Title;
            book.Author = update.Author;
            book.PageNumber = update.PageNumber;
            book.ISBN13 = update.ISBN13;
            return book;
        }
        #endregion
    };


}

