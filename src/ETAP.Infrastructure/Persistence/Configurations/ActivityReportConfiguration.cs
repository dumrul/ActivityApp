using ETAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
public class ActivityReportConfiguration : IEntityTypeConfiguration<ActivityReport>
{
    public void Configure(EntityTypeBuilder<ActivityReport> builder)
    {
        builder.ToTable("ActivityReports");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Summary)
               .IsRequired()
               .HasMaxLength(2000);

        builder.Property(x => x.CreatedAt)
               .IsRequired();

        builder.HasOne(x => x.Activity)
               .WithMany()
               .HasForeignKey(x => x.ActivityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
}