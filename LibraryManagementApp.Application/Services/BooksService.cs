using LibraryManagementApp.Application.Dtos.Book;
using LibraryManagementApp.Domain.Exceptions;
using LibraryManagementApp.Domain.Queries;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Application.Interfaces.Services;
using LibraryManagementApp.Application.Mappers;

namespace LibraryManagementApp.Domain.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<List<BookResponseDto>> GetAllAsync(QueryObject queryObject)
    {
        var bookModels = await _booksRepository.GetAllAsync(queryObject);
        return bookModels.ToListOfResponseDtos();
    }

    public async Task<BookResponseDto> GetByIdAsync(int id)
    {
        var bookModel = await _booksRepository.GetByIdAsync(id);
        if (bookModel is null)
        {
            throw new BookNotFoundException(id);
        }

        return bookModel.ToBookDto();
    }

    public async Task<BookResponseDto> CreateAsync(BookCreateRequestDto bookDto)
    {
        var createdBookModel = await _booksRepository.CreateAsync(bookDto.ToBookModel());
        return createdBookModel.ToBookDto();
    }

    public async Task<BookResponseDto> UpdateAsync(int id, BookUpdateRequestDto bookDto)
    {
        var bookModel = await _booksRepository.GetByIdAsync(id);
        if (bookModel is null)
        {
            throw new BookNotFoundException(id);
        }

        bookDto.ToBookModel(id);

        var updatedBookModel = await _booksRepository.UpdateAsync(bookDto.ToBookModel(id));
        return updatedBookModel.ToBookDto();
    }

    public async Task DeleteAsync(int id)
    {
        var bookModel = await _booksRepository.GetByIdAsync(id);
        if (bookModel is null)
        {
            throw new BookNotFoundException(id);
        }

        await _booksRepository.DeleteAsync(id);
    }
}
