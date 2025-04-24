using Ardalis.GuardClauses;
using ETAP.Domain.Abstractions;
using ETAP.Domain.Entities.Identity;

namespace ETAP.Domain.Entities
{
    public sealed class AppUserToken : BaseEntity
    {
        public Guid UserId { get; private set; }
        public AppUser User { get; private set; } = null!;

        public string RefreshToken { get; private set; } = string.Empty;
        public DateTime ExpiresAt { get; private set; }
        public bool IsRevoked { get; private set; }

        private AppUserToken() { }

        public AppUserToken(Guid userId, string refreshToken, DateTime expiresAt)
        {
            UserId = Guard.Against.Default(userId, nameof(userId));
            RefreshToken = Guard.Against.NullOrWhiteSpace(refreshToken, nameof(refreshToken));
            ExpiresAt = Guard.Against.OutOfSQLDateRange(expiresAt, nameof(expiresAt));
            IsRevoked = false;
        }

        public void Revoke() => IsRevoked = true;
    }
}