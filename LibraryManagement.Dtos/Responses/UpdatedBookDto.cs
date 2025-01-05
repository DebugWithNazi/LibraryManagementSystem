using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Dtos.Responses
{
    public class UpdatedBookDto
    {
        public string ISBN { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
