using System.Text.RegularExpressions;
using Ardalis.GuardClauses;

namespace ETAP.Domain.Common.Guards
{
    public static class GuardExtensions
    {
        public static string InvalidEmail(this IGuardClause guardClause, string input, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Email boş olamaz.", parameterName);

            if (!Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Geçerli bir email adresi girilmelidir.", parameterName);

            return input;
        }
    }
}