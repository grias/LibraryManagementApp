using LibraryManagementApp.DataAccess.Contexts;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.DataAccess.Repositories;

public class EfBooksRepository : IBooksRepository
{
    private readonly ApplicationDbContext _context;

    public EfBooksRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
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
