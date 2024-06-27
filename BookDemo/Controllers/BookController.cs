using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //Ayırt etmeksizin getir.
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;

            if (books == null) 
                return NotFound();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name = "id")] int id)
        {
            //var books = ApplicationContext.Books;
            //if (id >= books.Count  || id < 0)
            //    return NotFound();
            //else 
            //    return Ok(books[id - 1]);

            var book = ApplicationContext.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();

            if (book is null)
                return NotFound();

            return Ok(book);

        }

        [HttpGet("{title}")]
        public IActionResult GetBookFromTitle([FromRoute(Name = "title")] string title)
        {
            var book = ApplicationContext.Books.Where(b => b.Title.Equals(title)).SingleOrDefault();

            if (book is null)
                return NoContent();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest();

                //Check if the book is already added.
                if ((ApplicationContext.Books.Where(b => b.Id.Equals(book.Id)).SingleOrDefault() is not null)
                    || (ApplicationContext.Books.Where(b => b.Id.Equals(book)).SingleOrDefault() is not null))
                    return BadRequest();

                ApplicationContext.Books.Add(book);
                return StatusCode(201,book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            //if (!ApplicationContext.Books.Any(b => b.Id == id))
            //    return BadRequest();

            

            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));

            if (entity is null)
                return NoContent();

            //Check id is correct or not.
            if (id != book.Id)
                return BadRequest("Entered book id is not equal to the given id");

            for (int i = 0; i < ApplicationContext.Books.Count; i++)
            {
                if (ApplicationContext.Books[i].Id == id)
                    ApplicationContext.Books[i] = book;
            }

            return Ok(ApplicationContext.Books);
        }

        [HttpDelete]
        public IActionResult DeleteAllBook()
        {
            ApplicationContext.Books.Clear();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"Book with id:{id} is not found"
                });

            ApplicationContext.Books.Remove(entity);
            return NoContent();
        }

    }
}
