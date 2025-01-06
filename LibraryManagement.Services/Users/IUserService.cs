using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Users
{
    public interface IUserService
    {
        Task<(int StatusCode, string Message)> CreateUserAsync(RegisterDto dto);
        Task<LoggedingWithTokenDto> LoginAsync(LoginDto dto);
        Task<bool> IsCurrentUserAdminAsync();
    }
}
