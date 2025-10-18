using LibraryManagementApp.Domain.Dtos.BookDtos;
using LibraryManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementApp.Domain.Mappers
{
    public static class BooksMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                PublishedYear = bookModel.PublishedYear,
                AuthorId = bookModel.AuthorId
            };
        }

        public static Book ToBookModel(this CreateBookDto bookDto)
        {
            return new Book()
            {
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                AuthorId = bookDto.AuthorId
            };
        }

        public static Book ToBookModel(this UpdateBookDto bookDto)
        {
            return new Book()
            {
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                AuthorId = bookDto.AuthorId
            };
        }
    }
}
