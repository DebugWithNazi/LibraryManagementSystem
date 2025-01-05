using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Dtos.Responses
{
    public class AddedBookDto
    {
        public string Isbn { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
