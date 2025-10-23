using LibraryManagementApp.Domain.Dtos.Book;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Interfaces.Services;
using LibraryManagementApp.Domain.Mappers;
using LibraryManagementApp.Domain.Exceptions;

namespace LibraryManagementApp.Domain.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<List<BookResponseDto>> GetAllAsync()
    {
        var bookModels = await _booksRepository.GetAllAsync();
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

        var updatedBookModel = await _booksRepository.UpdateAsync(bookModel);
        return updatedBookModel.ToBookDto();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var bookModel = await _booksRepository.GetByIdAsync(id);
        if (bookModel is null)
        {
            throw new BookNotFoundException(id);
        }

        await _booksRepository.DeleteAsync(id);
        return true;
    }
}
