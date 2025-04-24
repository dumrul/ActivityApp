using ETAP.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            // Tablo adı (opsiyonel - default: AspNetRoles)
            builder.ToTable("AppRoles");

            // Role adı zorunlu ve uzunluğu belirli
            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            // NormalizedName da genelde gereklidir
            builder.Property(r => r.NormalizedName)
                   .HasMaxLength(50);
        }
    }
}