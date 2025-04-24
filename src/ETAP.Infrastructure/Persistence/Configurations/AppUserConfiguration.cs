using ETAP.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Table name (Opsiyonel: default AspNetUsers)
            builder.ToTable("AppUsers");

            // FirstName - Required ve MaxLength
            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            // LastName - Required ve MaxLength
            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            // FullName - Map edilmez, sadece get-only olduğu için
            builder.Ignore(u => u.FullName);

            // One-to-many: AppUser (Organizer) -> Activities
            builder.HasMany(u => u.OrganizedActivities)
                   .WithOne(a => a.Organizer)
                   .HasForeignKey(a => a.OrganizerId)
                   .OnDelete(DeleteBehavior.Restrict); // Silince etkilenmesin

            // One-to-many: AppUser -> ActivityParticipant
            builder.HasMany(u => u.ParticipatedActivities)
                   .WithOne(ap => ap.User)
                   .HasForeignKey(ap => ap.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: AppUser -> Organization
            builder.HasOne(u => u.Organization)
                   .WithMany(o => o.Users)
                   .HasForeignKey(u => u.OrganizationId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}