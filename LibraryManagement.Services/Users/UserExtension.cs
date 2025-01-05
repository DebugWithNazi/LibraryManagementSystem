using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Users
{
    public static class UserExtension
    {
        public static bool IsPotentialSqlInjection(this string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            string[] sqlInjectionKeywords = { "SELECT", "INSERT", "DELETE", "DROP", "UPDATE", "EXEC", "--", ";--", ";", "/*", "*/", "@@", "@" };
            string lowerInput = input.ToUpperInvariant();

            return sqlInjectionKeywords.Any(keyword => lowerInput.Contains(keyword));
        }

        public static bool isValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);

        }
    }
}
