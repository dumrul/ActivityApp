using ETAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
public class UserTokenConfiguration : IEntityTypeConfiguration<AppUserToken>
{
    public void Configure(EntityTypeBuilder<AppUserToken> builder)
    {
        builder.ToTable("UserTokens");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.RefreshToken)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(x => x.ExpiresAt)
               .IsRequired();

        builder.Property(x => x.IsRevoked)
               .HasDefaultValue(false);

        builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
}