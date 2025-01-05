using LibraryManagement.Dtos.Responses;
using LibraryManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Borrowing
{
    public static class BorrowExtension
    {
        public static BorrowedBookDto ToDto(this BorrowRecord book)
        {
            if (book == null) throw new ArgumentNullException(nameof(BorrowRecord));

            return new BorrowedBookDto
            {
                Isbn = book.ISBN,
                BorrowedAt = book.BorrowedAt,
                ReturnedAt = book.ReturnedAt
            };
        }
    }
}
