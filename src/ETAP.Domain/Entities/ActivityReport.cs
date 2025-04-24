using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using ETAP.Domain.Abstractions;

namespace ETAP.Domain.Entities
{
    public sealed class ActivityReport : BaseEntity
    {
        public Guid ActivityId { get; private set; }
        public Activity Activity { get; private set; } = null!;

        public string Summary { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

        private ActivityReport() { }

        public ActivityReport(Guid activityId, string summary)
        {
            ActivityId = Guard.Against.Default(activityId, nameof(activityId));
            Summary = Guard.Against.NullOrWhiteSpace(summary, nameof(summary));
            CreatedAt = DateTime.UtcNow;
        }
    }
}