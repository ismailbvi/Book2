using BookStore.BL.Interfaces;
using BookStore.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Booke.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("GetAllBooksByAuthor")]
        public async Task<IActionResult>
            GetAllBooksByAuthor(Guid authorId)
        {
            var result =
                await _libraryService.GetAllBooksByAuthor(authorId);

            if (result?.Author == null) return NotFound(authorId);

            return Ok(result);
        }
    }
}
