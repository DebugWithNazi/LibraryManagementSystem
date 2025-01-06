using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using LibraryManagement.Infrastructure.Contexts;
using LibraryManagement.Infrastructure.Entities;
using LibraryManagement.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Borrowing
{
    public class BorrowService : IBorrowService
    {
        public readonly LibraryDbContext _context;
        private readonly IUserService _userService;

        public BorrowService(IUserService userService, LibraryDbContext context)
        {
            _context = context;
            _userService = userService;

        }

        public async Task<AddedBorrowBookDto> BorrowBook(AddBorrowBookDto request, string userId)
        {
            var existingBorrow = await _context.BorrowRecords
               .FirstOrDefaultAsync(b => b.ISBN == request.Isbn && b.ReturnedAt == null);

            if (existingBorrow != null)
            {
                throw new InvalidOperationException("This book is currently borrowed by another user.");
            }

            var userBorrowCount = await _context.BorrowRecords
                .CountAsync(b => b.UserId == userId && b.ReturnedAt == null);

            if (userBorrowCount >= 2)
            {
                throw new InvalidOperationException("You have already borrowed the maximum allowed books.");
            }

            var borrowRecord = new BorrowRecord
            {
                ISBN = request.Isbn,
                UserId = userId,
                BorrowedAt = DateTime.UtcNow
            };

            _context.BorrowRecords.Add(borrowRecord);
            await _context.SaveChangesAsync();

            return new AddedBorrowBookDto
            {
                Isbn = borrowRecord.ISBN,
                BorrowedAt = borrowRecord.BorrowedAt
            };
        }

        public async Task<List<BorrowedBookDto>> GetBorrowedBooks(string userId)
        {
            bool isAdmin = await _userService.IsCurrentUserAdminAsync();
            if (isAdmin)
            {
                return await _context.BorrowRecords
                                   .Where(b => b.ReturnedAt == null)
                                   .OrderByDescending(x => x.BorrowedAt).Select(b => b.ToDto())
                                   .ToListAsync();
            }
            else
            {
                return await _context.BorrowRecords
                               .Where(b => b.UserId == userId && b.ReturnedAt == null)
                               .OrderByDescending(x => x.BorrowedAt).Select(b => b.ToDto())
                               .ToListAsync();
            }
        }

        public async Task<List<BorrowedBookDto>> GetReturnedBooks(string userId)
        {
            bool isAdmin = await _userService.IsCurrentUserAdminAsync();
            if (isAdmin)
            {
                return await _context.BorrowRecords
                               .OrderByDescending(x => x.BorrowedAt).Select(b => b.ToDto())
                               .ToListAsync();
            }
            else
            {
                return await _context.BorrowRecords
                               .Where(b => b.UserId == userId)
                               .OrderByDescending(x => x.BorrowedAt).Select(b => b.ToDto())
                               .ToListAsync();
            }
        }

        public async Task<bool> ReturnBook(string isbn, string userId)
        {
            bool isAdmin = await _userService.IsCurrentUserAdminAsync();
            BorrowRecord? borrowRecord;
            if (isAdmin)
            borrowRecord = await _context.BorrowRecords
               .FirstOrDefaultAsync(b => b.ISBN == isbn && b.ReturnedAt == null);
            else
                borrowRecord = await _context.BorrowRecords
                   .FirstOrDefaultAsync(b => b.ISBN == isbn && b.UserId == userId && b.ReturnedAt == null);

            if (borrowRecord == null)
            {
                return false;
            }
            borrowRecord.ReturnedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
