using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Books
{
    public interface IBookService
    {
        Task<List<AddedBookDto>?> CreateBooksAsync(List<AddBookDto> request);
        Task<PaginatedBooksDto> GetListBooksAsync(int page = 0);
        Task<bool> DeleteBookAsync(string isbn);
        Task<UpdatedBookDto?> UpdateBookAsync(string isbn, UpdateBookDto dto);
    }
}
