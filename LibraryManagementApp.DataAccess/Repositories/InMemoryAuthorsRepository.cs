using LibraryManagementApp.Domain.Entities;
using LibraryManagementApp.Domain.Helpers;
using LibraryManagementApp.Domain.Interfaces.Repositories;

namespace LibraryManagementApp.DataAccess.Repositories;

public class InMemoryAuthorsRepository : IAuthorsRepository
{
    private readonly List<Author> _authorsSet;
    
    private int NewId
    {
        get
        {
            if (_authorsSet.Count == 0)
            {
                return 1;
            }
            return _authorsSet.OrderByDescending(author => author.Id).FirstOrDefault().Id + 1;
        }
    }

    public InMemoryAuthorsRepository()
    {
        _authorsSet = new List<Author>()
        {
            new Author() {Id = 1, Name = "Unknown author"},
            new Author() {Id = 2, Name = "J. R. R. Tolkien", DateOfBirth = new DateOnly(1892, 1, 3)},
            new Author() {Id = 3, Name = "J. K. Rowling", DateOfBirth = new DateOnly(1965, 7, 31)},
        };
    }

    public async Task<List<Author>> GetAllAsync(QueryObject queryObject)
    {
        var authors = _authorsSet.AsQueryable();

        return authors.FilterByName(queryObject).Paginate(queryObject).ToList();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return _authorsSet.Find(author => author.Id == id);
    }

    public async Task<Author> CreateAsync(Author createdAuthor)
    {
        createdAuthor.Id = NewId;
        _authorsSet.Add(createdAuthor);
        return createdAuthor;
    }
    public async Task<Author?> UpdateAsync(Author updatedAuthor)
    {
        var oldAuthor = await GetByIdAsync(updatedAuthor.Id);
        if (oldAuthor is null)
        {
            return null;
        }
        _authorsSet.Remove(oldAuthor);
        _authorsSet.Add(updatedAuthor);
        return updatedAuthor;
    }

    public async Task<Author?> DeleteAsync(int id)
    {
        var authorToRemove = await GetByIdAsync(id);
        if (authorToRemove is null)
        {
            return null;
        }

        _authorsSet.Remove(authorToRemove);
        return authorToRemove;
    }
}
