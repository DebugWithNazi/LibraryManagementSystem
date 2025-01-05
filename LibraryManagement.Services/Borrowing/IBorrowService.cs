using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Borrowing
{
    public interface IBorrowService
    {
        Task<AddedBorrowBookDto> BorrowBook(AddBorrowBookDto request, string userId);
        Task<bool> ReturnBook(string isbn, string userId);
        Task<List<BorrowedBookDto>> GetBorrowedBooks(string userId);
    }
}
