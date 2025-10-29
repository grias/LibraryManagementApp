using LibraryManagementApp.Infrastructure.Contexts;
using LibraryManagementApp.Domain.Entities;
using LibraryManagementApp.Domain.Helpers;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Infrastructure.Repositories;

public class EfBooksRepository : IBooksRepository
{
    private readonly ApplicationDbContext _context;

    public EfBooksRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllAsync(QueryObject queryObject)
    {
        var books = _context.Books.Include(x => x.Author).AsQueryable();

        return await books
            .FilterByPublishingDateRange(queryObject)
            .FilterByTitle(queryObject)
            .FilterByAuthorName(queryObject)
            .Paginate(queryObject).ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
        {
            return null;
        }

        await _context.Authors.FindAsync(book.AuthorId);

        return book;
    }

    public async Task<Book> CreateAsync(Book entity)
    {
        await _context.Books.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Book?> UpdateAsync(Book entity)
    {
        var bookToUpdate = await GetByIdAsync(entity.Id);
        if (bookToUpdate is null)
        {
            return null;
        }

        bookToUpdate.Title = entity.Title;
        bookToUpdate.PublishedYear = entity.PublishedYear;
        bookToUpdate.AuthorId = entity.AuthorId;
        await _context.SaveChangesAsync();

        return bookToUpdate;
    }

    public async Task<Book?> DeleteAsync(int id)
    {
        var bookToDelete = await GetByIdAsync(id);
        if (bookToDelete is null)
        {
            return null;
        }

        _context.Books.Remove(bookToDelete);
        await _context.SaveChangesAsync();

        return bookToDelete;
    }
}
