using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using LibraryManagement.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
       
        public async Task<(int StatusCode, string Message)> CreateUserAsync(RegisterDto dto)
        {
            if (dto.Username.IsPotentialSqlInjection())
            {
                return (0, "The username contains potential SQL injection patterns.");
            }
            else if (!dto.Email.isValidEmail())
            {
                return (1, "The e-mail is invalid.");
            }
            else if (dto.Username.Length > 50)
            {
                return (2, "The username is too long.");
            }
            else if (await _userManager.FindByEmailAsync(dto.Email) != null)
            {
                return (4, "The e-mail already exists.");
            }
            else if (await _userManager.FindByNameAsync(dto.Username) != null)
            {
                return (5, "The username already exists.");
            }
            var passwordValidator = new PasswordValidator<ApplicationUser>();
            var passwordValidationResult = await passwordValidator.ValidateAsync(_userManager, null, dto.Password);
            if (!passwordValidationResult.Succeeded)
            {
                return (8, "The password is too weak.");
            }
            var user = new ApplicationUser { UserName = dto.Username, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return (3, "User registered successfully.");
            }
            return (1, string.Join("; ", result.Errors.Select(e => e.Description)));
        }

        public async Task<LoggedingWithTokenDto> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                var sessionToken = await GenerateJwtToken(user);

                return new LoggedingWithTokenDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    SessionToken = sessionToken
                };
            }
            return null;
        }

        public async Task<bool> IsCurrentUserAdminAsync()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return roles.Contains("Admin");
            }
            return false;
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            bool isAdmin = roles.Contains("Admin");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("isAdmin", isAdmin.ToString()),
                new Claim("username", user.UserName.ToString())
                
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpireAfterMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                return await _userManager.FindByIdAsync(userId);
            }
            return null;
        }
    }
}
