using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementApp.DataAccess.Repositories;

public class InMemoryBooksRepository : IBooksRepository
{
    private readonly List<Book> _booksSet;

    private int _newId;
    private int NewId { get => _newId++; init; }

    public InMemoryBooksRepository()
    {
        _booksSet = new List<Book>()
        {
            new Book() {Id = 1, Title = "Three little pigs", AuthorId = 1 , PublishedYear = 2007},
            new Book() {Id = 2, Title = "The lord of the rings", AuthorId = 2 , PublishedYear = 1954},
            new Book() {Id = 3, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 3 , PublishedYear = 1997},
            new Book() {Id = 4, Title = "Harry Potter and the Chamber of Secrets", AuthorId = 3 , PublishedYear = 1898},
        };

        NewId = _booksSet.Count + 1;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return _booksSet;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return _booksSet.FirstOrDefault(book => book.Id == id);
    }

    public async Task<Book> CreateAsync(Book entity)
    {
        _booksSet.Add(entity);
        return entity;
    }
    public async Task<Book?> UpdateAsync(Book updatedBook)
    {
        var oldBook = await GetByIdAsync(updatedBook.Id);
        _booksSet.Remove(oldBook);
        _booksSet.Add(updatedBook);
        return updatedBook;   
    }

    public async Task<Book> DeleteAsync(int id)
    {
        var bookToRemove = await GetByIdAsync(id);
        _booksSet.Remove(bookToRemove);

        return bookToRemove;
    }
}
