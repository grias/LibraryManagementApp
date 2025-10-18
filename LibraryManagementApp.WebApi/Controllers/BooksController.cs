using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementApp.Domain.Dtos.BookDtos;
using LibraryManagementApp.Domain.Interfaces.Services;

namespace LibraryManagementApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _booksService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _booksService.GetByIdAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _booksService.CreateAsync(book);

            return Ok();
        }

        [HttpPut("id:int")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedBook = await _booksService.TryUpdateAsync(id, book);

            if (updatedBook is null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var found = await _booksService.DeleteAsync(id);

            if (!found)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
