using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Dtos.Responses
{
    public class AddedBorrowBookDto
    {
        public string Isbn { get; set; }
        public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;
    }
}
