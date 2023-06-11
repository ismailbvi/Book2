using System.Net;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.Models.Data;
using BookStore.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Booke.Control
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService) => _authorService = authorService;

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(IEnumerable<Author>))]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAll());
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(Author))]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
            StatusCodes.Status404NotFound)]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == null) return BadRequest(id);

            var result = await _authorService.GetById(id);

            if (result != null) return Ok(result);

            return NotFound();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Author author)
        {
            await _authorService.Add(author);
            return Ok();
        }
        [HttpPost("Update")]
        public async Task Update([FromBody] Author author)
        {
            await _authorService.Update(author);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid authorId)
        {
            await _authorService.Delete(authorId);

            return Ok();
        }
    }
}
