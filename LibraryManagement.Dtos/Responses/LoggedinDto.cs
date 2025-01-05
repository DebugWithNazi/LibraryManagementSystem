using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Dtos.Responses
{
    public class LoggedinDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }

    public class LoggedingWithTokenDto : LoggedinDto
    {
        public string SessionToken { get; set; }
    }
}
