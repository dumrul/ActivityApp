using ETAP.Domain.Abstractions;

namespace ETAP.Domain.Enums
{
    public sealed class ActivityStatus : BaseSmartEnum<ActivityStatus>
    {
        public ActivityStatus(string name, int value, string displayName) : base(name, value, displayName)
        {

        }

        public static readonly ActivityStatus Planned = new("Planned", 1, "Planlandı");
        public static readonly ActivityStatus Cancelled = new("Cancelled", 2, "İptal");
        public static readonly ActivityStatus Completed = new("Completed", 3, "Tamamlandı");
    }
}