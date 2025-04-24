using Ardalis.GuardClauses;
using ETAP.Domain.Abstractions;
using ETAP.Domain.Entities.Identity;

namespace ETAP.Domain.Entities
{
    public sealed class Invitation : BaseEntity
    {
        public Guid ActivityId { get; private set; }
        public Activity Activity { get; private set; } = null!;

        public Guid InvitedUserId { get; private set; }
        public AppUser InvitedUser { get; private set; } = null!;

        public DateTime SentAt { get; private set; }
        public bool IsAccepted { get; private set; }

        private Invitation() { }

        public Invitation(Guid activityId, Guid invitedUserId)
        {
            ActivityId = Guard.Against.Default(activityId, nameof(activityId));
            InvitedUserId = Guard.Against.Default(invitedUserId, nameof(invitedUserId));
            SentAt = DateTime.UtcNow;
            IsAccepted = false;
        }

        public void Accept()
        {
            if (IsAccepted)
                throw new InvalidOperationException("Davet zaten kabul edilmiş.");

            IsAccepted = true;
        }
    }
}