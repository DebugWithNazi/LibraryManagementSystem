using LibraryManagement.Dtos.Requests;
using LibraryManagement.Services.Borrowing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        [HttpPost("borrow")]
        [Authorize]
        public async Task<IActionResult> BorrowBook([FromBody] AddBorrowBookDto request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _borrowService.BorrowBook(request, userId);
            return Ok(result);
        }

        [HttpDelete("return/{isbn}")]
        [Authorize]
        public async Task<IActionResult> ReturnBook(string isbn)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _borrowService.ReturnBook(isbn, userId);

            if (!result)
            {
                return NotFound("You have not borrowed this book or it has already been returned.");
            }
            return NoContent();
        }

        [HttpGet("borrowed")]
        [Authorize]
        public async Task<IActionResult> GetBorrowedBooks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var borrowedBooks = await _borrowService.GetBorrowedBooks(userId);

            return Ok(new
            {
                Books = borrowedBooks
            });
        }

        [HttpGet("returned")]
        [Authorize]
        public async Task<IActionResult> GetReturnedBooks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var borrowedBooks = await _borrowService.GetReturnedBooks(userId);

            return Ok(new
            {
                Books = borrowedBooks
            });
        }
    }
}
