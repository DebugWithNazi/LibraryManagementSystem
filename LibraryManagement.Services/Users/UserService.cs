using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using LibraryManagement.Infrastructure.Entities;
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

        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
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
                var sessionToken = GenerateJwtToken(user);

                return new LoggedingWithTokenDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    SessionToken = sessionToken
                };
            }
            return null;
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email)
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
    }
}
