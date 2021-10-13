using Assignment2.Managers;
using BookLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManager _manager = new BooksManager();
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Book>> Get()
        {
            IEnumerable<Book> books = _manager.GetAll();
            if (books == null)
                return NotFound();
            return Ok(books);
        }
        [HttpGet("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> Get(string isbn)
        {
            var book = _manager.GetBookByISBN(isbn);
            if (book is null)
                return NotFound();
            return Ok(book);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Book> Post([FromBody] Book value)
        {
            Book book = _manager.Create(value);
            if (book == null)
            {
                return BadRequest("Data was null");
            }

            return Ok(book);
        }

    }
}
