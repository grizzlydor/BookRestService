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
        #region GetAll
        // GET: api/<BooksController>
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
        #endregion
        #region GetBookByISBN
        // GET: api/<BooksController>/<i>isbn</i>
        [HttpGet("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> Get(string isbn)
        {
            var book = _manager.GetBookByISBN(isbn);
            if (book == null)
                return NotFound();
            return Ok(book);
        }
        #endregion
        #region Create
        // POST: api/<BooksController>/Add
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
        #endregion
        #region Update
        // PUT: api/<BooksController>/Update
        [HttpPut("{isbn}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Book> Put(string isbn, [FromBody] Book book)
        {
            var updatedBook = _manager.Update(isbn, book);
            if (updatedBook == null)
                return NoContent();
            return Ok(updatedBook);
        }
        #endregion
        #region Delete
        // DELETE: api/<BooksController>/Delete
        [HttpDelete("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Book> Delete(string isbn)
        {
            Book book = _manager.Delete(isbn);
            if (book == null)
            {
                return BadRequest("Data was null");
            }
            return Ok(book);
        }
        #endregion
    }
}
