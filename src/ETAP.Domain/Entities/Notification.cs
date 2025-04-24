using Ardalis.GuardClauses;
using ETAP.Domain.Abstractions;
using ETAP.Domain.Entities.Identity;

namespace ETAP.Domain.Entities
{
    public sealed class Notification : BaseEntity
    {
        public Guid UserId { get; private set; }
        public AppUser User { get; private set; } = null!;

        public string Message { get; private set; } = string.Empty;
        public bool IsRead { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Notification() { }

        public Notification(Guid userId, string message)
        {
            UserId = Guard.Against.Default(userId, nameof(userId));
            Message = Guard.Against.NullOrWhiteSpace(message, nameof(message));
            CreatedAt = DateTime.UtcNow;
            IsRead = false;
        }

        public void MarkAsRead() => IsRead = true;
    }
}