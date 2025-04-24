using ETAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
    public class ActivityParticipantConfiguration : IEntityTypeConfiguration<ActivityParticipant>
    {
        public void Configure(EntityTypeBuilder<ActivityParticipant> builder)
        {
            // Composite Key
            builder.HasKey(ap => new { ap.ActivityId, ap.UserId });

            // One-to-many: Activity -> ActivityParticipants
            builder.HasOne(ap => ap.Activity)
                   .WithMany(a => a.Participants)
                   .HasForeignKey(ap => ap.ActivityId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: AppUser -> ActivityParticipants
            builder.HasOne(ap => ap.User)
                   .WithMany(u => u.ParticipatedActivities)
                   .HasForeignKey(ap => ap.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // (Opsiyonel) Tablo adı
            builder.ToTable("ActivityParticipants");
        }
    }
}