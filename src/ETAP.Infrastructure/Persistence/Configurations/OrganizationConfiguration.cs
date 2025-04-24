using ETAP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETAP.Infrastructure.Persistence.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            // Tablo adı
            builder.ToTable("Organizations");

            // Name alanı zorunlu ve max 100 karakter
            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // One-to-many: Organization -> Users
            builder.HasMany(o => o.Users)
                   .WithOne(u => u.Organization)
                   .HasForeignKey(u => u.OrganizationId)
                   .OnDelete(DeleteBehavior.SetNull); // Organizasyon silinirse kullanıcılar boşa düşsün

            // One-to-many: Organization -> Activities
            builder.HasMany(o => o.Activities)
                   .WithOne(a => a.Organization)
                   .HasForeignKey(a => a.OrganizationId)
                   .OnDelete(DeleteBehavior.Cascade); // Organizasyon silinirse etkinlikler de silinsin
        }
    }
}