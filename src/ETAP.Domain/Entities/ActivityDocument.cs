using Ardalis.GuardClauses;
using ETAP.Domain.Abstractions;

namespace ETAP.Domain.Entities
{
    public sealed class ActivityDocument : BaseEntity
    {
        public Guid ActivityId { get; private set; }
        public Activity Activity { get; private set; } = null!;

        public string FileName { get; private set; } = string.Empty;
        public string FilePath { get; private set; } = string.Empty;

        public DateTime UploadedAt { get; private set; }

        private ActivityDocument() { }

        public ActivityDocument(Guid activityId, string fileName, string filePath)
        {
            ActivityId = Guard.Against.Default(activityId, nameof(activityId));
            FileName = Guard.Against.NullOrWhiteSpace(fileName, nameof(fileName));
            FilePath = Guard.Against.NullOrWhiteSpace(filePath, nameof(filePath));
            UploadedAt = DateTime.UtcNow;
        }
    }
}