using BookLibrary;
using System.Collections.Generic;

namespace Assignment2.Managers
{
    public class BooksManager
    {

        private static List<Book> _books = new List<Book>()
        {
            new Book() {Title = "JavaScript and JQuery: Interactive Front-End Web Development",
                Author = "Jon Duckett", PageNumber = 645, ISBN13 = 978-1118531648},
            new Book() {Title = "The Agile Samurai: How Agile Masters Deliver Great Software (Pragmatic Programmers)",
                Author = "Jonathan Rasmusson", PageNumber = 267 , ISBN13 = 978-1934356586},
            new Book() {Title = "Extreme Programming Explained",
                    Author = "Kent Beck, Cynthia Andres", PageNumber = 224, ISBN13 = 978-0321278654}
        };

        public IEnumerable<Book> GetAll()
        {
            return new List<Book>(_books);
        }
        public Book GetBookByISBN(int isbn)
        {
            Book book = _books.Find(b => b.ISBN13 == isbn);
                return book;
        }
    };


}

