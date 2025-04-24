using ETAP.Domain.Enums;
using ETAP.Domain.Abstractions;
using ETAP.Domain.Entities.Identity;
using Ardalis.GuardClauses;
using ETAP.Domain.Common.Guards;

namespace ETAP.Domain.Entities
{
    public sealed class Activity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = string.Empty;

        // SmartEnum ile tanımlanan kategori ve durum
        public ActivityCategory Category { get; set; } = ActivityCategory.Meeting;
        public ActivityStatus Status { get; set; } = ActivityStatus.Planned;

        // Organizasyonu temsil eder
        public Guid OrganizationId { get; set; }
        public required Organization Organization { get; set; }

        // Etkinlik oluşturucusu (Organizatör)
        public Guid OrganizerId { get; set; }
        public required AppUser Organizer { get; set; }

        public ICollection<ActivityParticipant> Participants { get; set; } = new List<ActivityParticipant>();

        // Katılımcılarla ilişki kurulabilir, istersek ileride ekleriz
        // public ICollection<AppUser> Participants { get; set; } = new List<AppUser>();

        private Activity() { }

        public Activity(
            string title,
            string description,
            DateTime startDate,
            DateTime endDate,
            string location,
            ActivityCategory category,
            Guid organizationId,
            Guid organizerId)
        {
            Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            Description = description?.Trim() ?? string.Empty;
            Location = Guard.Against.NullOrWhiteSpace(location, nameof(location));

            Guard.Against.OutOfRange(startDate, nameof(startDate), DateTime.UtcNow, DateTime.MaxValue);
            Guard.Against.OutOfRange(endDate, nameof(endDate), startDate, DateTime.MaxValue);

            Category = Guard.Against.InvalidActivityCategory(category, nameof(category));
            Status = Guard.Against.InvalidActivityStatus(ActivityStatus.Planned, nameof(Status));

            OrganizationId = Guard.Against.Default(organizationId, nameof(organizationId));
            OrganizerId = Guard.Against.Default(organizerId, nameof(organizerId));
        }

        public void Cancel()
        {
            if (Status == ActivityStatus.Cancelled)
                throw new InvalidOperationException("Etkinlik zaten iptal edilmiş.");

            Status = ActivityStatus.Cancelled;
        }

        public void Complete()
        {
            if (Status == ActivityStatus.Completed)
                throw new InvalidOperationException("Etkinlik zaten tamamlanmış.");

            Status = ActivityStatus.Completed;
        }
    }
}