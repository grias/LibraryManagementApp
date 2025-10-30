using LibraryManagementApp.Application.Dtos.Author;
using LibraryManagementApp.Application.Interfaces.Services;
using LibraryManagementApp.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorsService _authorService;

    public AuthorsController(IAuthorsService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var authors = await _authorService.GetAllAsync(queryObject);
        return Ok(authors);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var author = await _authorService.GetByIdAsync(id);

        if (author is null)
        {
            return NotFound();
        }

        return Ok(author);
    }

    [HttpGet("{id:int}/Books")]
    public async Task<IActionResult> GetBooksByAuthorId([FromRoute] int id, [FromQuery] QueryObject queryObject)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var books = await _authorService.GetBooksByAuthorIdAsync(id, queryObject);
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorCreateRequestDto author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdAuthor = await _authorService.CreateAsync(author);

        return Ok(createdAuthor);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AuthorUpdateRequestDto author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedAuthor = await _authorService.UpdateAsync(id, author);

        if (updatedAuthor is null)
        {
            return NotFound();
        }

        return Ok(updatedAuthor);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        await _authorService.DeleteAsync(id);

        return NoContent();
    }
}
