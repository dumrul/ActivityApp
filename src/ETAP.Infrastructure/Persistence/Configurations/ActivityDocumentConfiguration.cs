using ETAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
public class ActivityDocumentConfiguration : IEntityTypeConfiguration<ActivityDocument>
{
    public void Configure(EntityTypeBuilder<ActivityDocument> builder)
    {
        builder.ToTable("ActivityDocuments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(x => x.FilePath)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(x => x.UploadedAt)
               .IsRequired();

        builder.HasOne(x => x.Activity)
               .WithMany()
               .HasForeignKey(x => x.ActivityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
}