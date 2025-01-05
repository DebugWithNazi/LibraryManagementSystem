using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Dtos.Responses
{
    public class PaginatedBooksDto
    {
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
