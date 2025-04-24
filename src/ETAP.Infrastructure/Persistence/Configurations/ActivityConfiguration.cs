using ETAP.Domain.Entities;
using ETAP.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(a => a.Category)
                   .HasConversion(new ActivityCategoryConverter());

            builder.Property(a => a.Status)
                   .HasConversion(new ActivityStatusConverter());
        }
    }
}