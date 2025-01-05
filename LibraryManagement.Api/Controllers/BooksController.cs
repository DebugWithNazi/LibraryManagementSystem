using LibraryManagement.Dtos.Requests;
using LibraryManagement.Services.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBooks([FromBody] AddBookListDto request)
        {
            var addedBooks = await _bookService.CreateBooksAsync(request.Books);
            return StatusCode(201, addedBooks);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListBooks([FromQuery] int page = 0)
        {
            var response = await _bookService.GetListBooksAsync(page);
            return Ok(response);
        }

        [HttpPut("{isbn}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook([FromRoute] string isbn, [FromBody] UpdateBookDto dto)
        {
            var book = await _bookService.UpdateBookAsync(isbn, dto);

            if (book == null)
            {
                return NotFound($"No book found with ISBN {isbn}");
            }
            return Ok(book);
        }

        [HttpDelete("{isbn}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook([FromRoute] string isbn)
        {
            var response = await _bookService.DeleteBookAsync(isbn);
            if (!response)
            {
                return NotFound($"No book found with ISBN {isbn}");
            }
            return NoContent();
        }
    }
}
