using LibraryManagementApp.DataAccess.Contexts;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Entities;
using LibraryManagementApp.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.DataAccess.Repositories;

public class EfAuthorsRepository : IAuthorsRepository
{
    private readonly ApplicationDbContext _context;

    public EfAuthorsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAllAsync(QueryObject queryObject)
    {
        var authors = _context.Authors.Include(x => x.Books).AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryObject.AuthorName))
        {
            authors = authors.Where(author => author.Name.Contains(queryObject.AuthorName));
        }

        var pagesToSkip = (queryObject.PageNumber - 1) * queryObject.PageSize;
        return await authors.Skip(pagesToSkip).Take(queryObject.PageSize).ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author is null)
        {
            return null;
        }

        await _context.Books.Where(book => book.AuthorId == author.Id).ToListAsync();

        return author;
    }

    public async Task<Author> CreateAsync(Author entity)
    {
        await _context.Authors.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
    public async Task<Author?> UpdateAsync(Author entity)
    {
        var authorToUpdate = await GetByIdAsync(entity.Id);
        if (authorToUpdate is null)
        {
            return null;
        }

        authorToUpdate.Name = entity.Name;
        authorToUpdate.DateOfBirth = entity.DateOfBirth;
        await _context.SaveChangesAsync();

        return authorToUpdate;
    }

    public async Task<Author?> DeleteAsync(int id)
    {
        var authorToDelete = await GetByIdAsync(id);
        if (authorToDelete is null)
        {
            return null;
        }

        _context.Authors.Remove(authorToDelete);
        await _context.SaveChangesAsync();

        return authorToDelete;
    }
}
