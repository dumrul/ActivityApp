using Ardalis.GuardClauses;
using ETAP.Domain.Abstractions;
using ETAP.Domain.Entities.Identity;

namespace ETAP.Domain.Entities
{
public sealed class AuditLog : BaseEntity
{
    public Guid UserId { get; private set; }
    public AppUser User { get; private set; } = null!;

    public string Action { get; private set; } = string.Empty;
    public DateTime Timestamp { get; private set; }

    private AuditLog() { }

    public AuditLog(Guid userId, string action)
    {
        UserId = Guard.Against.Default(userId, nameof(userId));
        Action = Guard.Against.NullOrWhiteSpace(action, nameof(action));
        Timestamp = DateTime.UtcNow;
    }
}
}