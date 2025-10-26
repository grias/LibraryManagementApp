using LibraryManagementApp.Domain.Entities;
using LibraryManagementApp.Domain.Helpers;
using LibraryManagementApp.Domain.Interfaces.Repositories;

namespace LibraryManagementApp.DataAccess.Repositories;

public class InMemoryBooksRepository : IBooksRepository
{
    private readonly List<Book> _booksSet;

    private int NewId
    {
        get
        {
            if (_booksSet.Count == 0)
            {
                return 1;
            }
            return _booksSet.OrderByDescending(book => book.Id).FirstOrDefault().Id + 1;
        }
    }

    public InMemoryBooksRepository()
    {
        _booksSet = new List<Book>()
        {
            new Book() {Id = 1, Title = "Three little pigs", AuthorId = 1 , PublishedYear = 2007},
            new Book() {Id = 2, Title = "The lord of the rings", AuthorId = 2 , PublishedYear = 1954},
            new Book() {Id = 3, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 3 , PublishedYear = 1997},
            new Book() {Id = 4, Title = "Harry Potter and the Chamber of Secrets", AuthorId = 3 , PublishedYear = 1898},
        };
    }

    public async Task<List<Book>> GetAllAsync(QueryObject queryObject)
    {
        var books = _booksSet.AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryObject.BookTitle))
        {
            books = books.Where(book => book.Title.Contains(queryObject.BookTitle));
        }

        var pagesToSkip = (queryObject.PageNumber - 1) * queryObject.PageSize;
        return books.Skip(pagesToSkip).Take(queryObject.PageSize).ToList();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return _booksSet.FirstOrDefault(book => book.Id == id);
    }

    public async Task<Book> CreateAsync(Book createdBook)
    {
        createdBook.Id = NewId;
        _booksSet.Add(createdBook);
        return createdBook;
    }
    public async Task<Book?> UpdateAsync(Book updatedBook)
    {
        var oldBook = await GetByIdAsync(updatedBook.Id);
        if (oldBook is null)
        {
            return null;
        }

        _booksSet.Remove(oldBook);
        _booksSet.Add(updatedBook);
        return updatedBook;   
    }

    public async Task<Book?> DeleteAsync(int id)
    {
        var bookToRemove = await GetByIdAsync(id);
        if (bookToRemove is null)
        {
            return null;
        }
        _booksSet.Remove(bookToRemove);
        return bookToRemove;
    }
}
