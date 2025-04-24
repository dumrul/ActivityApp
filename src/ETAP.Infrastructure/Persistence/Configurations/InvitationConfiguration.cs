using ETAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable("Invitations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SentAt)
                   .IsRequired();

            builder.Property(x => x.IsAccepted)
                   .HasDefaultValue(false);

            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InvitedUser)
                   .WithMany()
                   .HasForeignKey(x => x.InvitedUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}