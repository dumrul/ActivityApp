using ETAP.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ETAP.Infrastructure.Persistence.Converters
{
    public class ActivityStatusConverter : ValueConverter<ActivityStatus, int>
    {
        public ActivityStatusConverter()
            : base(
                  status => status.Value,
                  value => ActivityStatus.FromValue(value))
        {
        }
    }
}