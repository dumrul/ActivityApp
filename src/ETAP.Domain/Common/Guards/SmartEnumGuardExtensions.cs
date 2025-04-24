using Ardalis.GuardClauses;
using ETAP.Domain.Enums;

namespace ETAP.Domain.Common.Guards
{
    public static class SmartEnumGuardExtensions
    {
        public static ActivityCategory InvalidActivityCategory(this IGuardClause guardClause, ActivityCategory? input, string parameterName)
        {
            if (input is null)
            {
                throw new ArgumentNullException(parameterName, "Etkinlik kategorisi null olamaz.");
            }

            if (!ActivityCategory.List.Contains(input))
            {
                throw new ArgumentException($"'{input.Name}' geçerli bir etkinlik kategorisi değildir.", parameterName);
            }

            return input;
        }

        public static ActivityStatus InvalidActivityStatus(this IGuardClause guardClause, ActivityStatus? input, string parameterName)
        {
            if (input is null)
            {
                throw new ArgumentNullException(parameterName, "Etkinlik durumu null olamaz.");
            }

            if (!ActivityStatus.List.Contains(input))
            {
                throw new ArgumentException($"'{input.Name}' geçerli bir etkinlik durumu değildir.", parameterName);
            }

            return input;
        }

    }
}