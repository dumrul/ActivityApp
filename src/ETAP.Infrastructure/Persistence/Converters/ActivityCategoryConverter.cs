using ETAP.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ETAP.Infrastructure.Persistence.Converters
{
    public class ActivityCategoryConverter : ValueConverter<ActivityCategory, int>
    {
        public ActivityCategoryConverter()
            : base(
                  category => category.Value,
                  value => ActivityCategory.FromValue(value))
        {
        }
    }
}