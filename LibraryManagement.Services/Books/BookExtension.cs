using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using LibraryManagement.Infrastructure.Entities;


namespace LibraryManagement.Services.Books
{
    public static class BookExtension
    {
        public static bool IsSameAs(this Book existingBook, AddBookDto newBookDto)
        {
            return existingBook.Title == newBookDto.Title &&
                   existingBook.Author == newBookDto.Author &&
                   existingBook.Edition == newBookDto.Edition &&
                   existingBook.Publisher == newBookDto.Publisher &&
                   existingBook.Genre == newBookDto.Genre &&
                   existingBook.PageCount == newBookDto.PageCount &&
                   existingBook.Language == newBookDto.Language &&
                   existingBook.PublicationYear == newBookDto.PublicationYear;
        }

        public static Book ToEntity(this AddBookDto bookDto)
        {
            if (bookDto == null) throw new ArgumentNullException(nameof(AddBookDto));

            return new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Edition = bookDto.Edition,
                Publisher = bookDto.Publisher,
                ISBN = bookDto.Isbn,
                Genre = bookDto.Genre,
                PageCount = bookDto.PageCount,
                Language = bookDto.Language,
                PublicationYear = bookDto.PublicationYear,
                AddedAt = DateTime.UtcNow
            };
        }
        public static BookDto ToDto(this Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(Book));
            return new BookDto
            {
                Title = book.Title,
                Author = book.Author,
                Edition = book.Edition,
                Publisher = book.Publisher,
                Isbn = book.ISBN,
                Genre = book.Genre,
                PageCount = book.PageCount,
                Language = book.Language,
                PublicationYear = book.PublicationYear,
                AddedAt = book.AddedAt,
                UpdatedAt = book.UpdatedAt
            };
        }
    }
}
