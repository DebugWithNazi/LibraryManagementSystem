using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using LibraryManagement.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Books
{
    public class BookService : IBookService
    {
        public readonly LibraryDbContext _context;
        public BookService(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<List<AddedBookDto>?> CreateBooksAsync(List<AddBookDto> request)
        {
            ValidateDuplicateBooksInRequest(request);

            var addedBooks = new List<AddedBookDto>();
            foreach (var book in request)
            {
                var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.ISBN == book.Isbn);
                if (existingBook != null)
                {
                    var message = existingBook.IsSameAs(book) ? "The book already exists" :
                        "A different book with same isbn exixst";
                    throw new InvalidOperationException(message);
                }
                var newBook = book.ToEntity();
                _context.Books.Add(newBook);
                addedBooks.Add(new AddedBookDto
                {
                    Isbn = newBook.ISBN,
                    AddedAt = newBook.AddedAt
                });
            }
            await _context.SaveChangesAsync();
            return addedBooks.OrderByDescending(x => x.Isbn).ToList();
        }

        public async Task<bool> DeleteBookAsync(string isbn)
        {
            var book = await _context.Books.Where(x => !x.IsDeleted && x.ISBN == isbn).FirstOrDefaultAsync();
            if (book == null)
            {
                return false;
            }

            book.IsDeleted = true;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PaginatedBooksDto> GetListBooksAsync(int page = 0)
        {
            const int pageSize = 10;
            var totalBooks = await _context.Books.Where(x => !x.IsDeleted).CountAsync();
            var totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);

            var response = new PaginatedBooksDto
            {
                Page = page,
                TotalPages = totalPages
            };  
            if(page < totalPages)
            {
                response.Books = await _context.Books.Where(x => !x.IsDeleted)
                    .OrderBy(x => x.ISBN)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .Select(x => x.ToDto())
                    .ToListAsync();
            }

            return response;
        }

        public async Task<UpdatedBookDto?> UpdateBookAsync(string isbn, UpdateBookDto dto)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
            if (book == null)
            {
                return null;
            }

            book.Title = dto.Title ?? book.Title;
            book.Author = dto.Author ?? book.Author;
            book.Edition = dto.Edition ?? book.Edition;
            book.Publisher = dto.Publisher ?? book.Publisher;
            book.Genre = dto.Genre ?? book.Genre;
            book.PageCount = dto.PageCount ?? book.PageCount;
            book.Language = dto.Language ?? book.Language;
            book.PublicationYear = dto.PublicationYear ?? book.PublicationYear;
            book.UpdatedAt = DateTime.UtcNow;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return new UpdatedBookDto
            {
                ISBN = book.ISBN,
                UpdatedAt = book.UpdatedAt.Value
            };
        }

        public void ValidateDuplicateBooksInRequest(List<AddBookDto> books)
        {
            var duplicateBooks = books.GroupBy(x => x.Isbn)
                                         .Where(g => g.Count() > 1)
                                         .ToList();
            if (duplicateBooks.Any())
            {
                throw new InvalidOperationException("The same book cannot be added twice!");
            }
        }
    }
}
