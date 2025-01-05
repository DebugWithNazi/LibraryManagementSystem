using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Dtos.Requests
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public int PublicationYear { get; set; }
    }

    public class AddBookListDto
    {
        public List<AddBookDto> Books { get; set; }

    }
}

