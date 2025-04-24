using System.Reflection;
using ETAP.Domain.Entities;
using ETAP.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETAP.Infrastructure.Persistence
{
    public class EtapDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public EtapDbContext(DbContextOptions<EtapDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities => Set<Activity>();
        public DbSet<ActivityParticipant> ActivityParticipants => Set<ActivityParticipant>();
        public DbSet<ActivityReport> ActivityReports => Set<ActivityReport>();
        public DbSet<ActivityDocument> ActivityDocuments => Set<ActivityDocument>();
        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<Invitation> Invitations => Set<Invitation>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<AppUserToken> AppUserTokens => Set<AppUserToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tüm IEntityTypeConfiguration<T> konfigürasyonlarını otomatik uygular
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}