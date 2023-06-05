using BookStore.BL.Interfaces;
using BookStore.Models.Data;
using BookStore.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Booke.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookService.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<Book?> GetById(Guid id)
        {
            return await _bookService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task Add([FromBody] AddBookRequest book)
        {
            await _bookService.Add(book);
        }

        [HttpDelete("Delete")]
        public async Task Delete(Guid bookId)
        {
            await _bookService.Delete(bookId);
        }
    }
}
