using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementApp.Domain.Interfaces;
using LibraryManagementApp.Domain.Dtos.AuthorDtos;

namespace LibraryManagementApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var author = await _authorService.GetByIdAsync(id);

            if (author is null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authorService.CreateAsync(author);

            return Ok();
        }

        [HttpPut("id:int")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (updatedAuthor, found) = await _authorService.TryUpdateAsync(id, author);

            if (!found)
            {
                return NotFound();
            }

            return Ok(updatedAuthor);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var found = await _authorService.DeleteAsync(id);

            if (!found)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
