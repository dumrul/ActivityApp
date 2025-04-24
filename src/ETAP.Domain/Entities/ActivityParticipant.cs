using Ardalis.GuardClauses;
using ETAP.Domain.Entities.Identity;

namespace ETAP.Domain.Entities
{
    public sealed class ActivityParticipant
    {
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        private ActivityParticipant() { }

        public ActivityParticipant(Guid activityId, Guid userId)
        {
            ActivityId = Guard.Against.Default(activityId, nameof(activityId));
            UserId = Guard.Against.Default(userId, nameof(userId));
        }
    }
}