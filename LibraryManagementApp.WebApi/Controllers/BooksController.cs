using LibraryManagementApp.Domain.Dtos.Book;
using LibraryManagementApp.Domain.Helpers;
using LibraryManagementApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.WebApi.Controllers;

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
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var books = await _booksService.GetAllAsync(queryObject);
        return Ok(books);
    }

    [HttpGet("{id:int}")]
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
    public async Task<IActionResult> Create([FromBody] BookCreateRequestDto book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdBook = await _booksService.CreateAsync(book);

        return Ok(createdBook);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookUpdateRequestDto book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedBook = await _booksService.UpdateAsync(id, book);

        if (updatedBook is null)
        {
            return NotFound();
        }

        return Ok(updatedBook);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        await _booksService.DeleteAsync(id);

        return NoContent();
    }
}
