using LibraryManagementApp.DataAccess.Contexts;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.DataAccess.Repositories;

public class EfAuthorsRepository : IAuthorsRepository
{
    private readonly ApplicationDbContext _context;

    public EfAuthorsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAllAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _context.Authors.FindAsync(id);
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
