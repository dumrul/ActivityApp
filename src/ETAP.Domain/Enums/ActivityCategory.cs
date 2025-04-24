using ETAP.Domain.Abstractions;

namespace ETAP.Domain.Enums
{
    public sealed class ActivityCategory : BaseSmartEnum<ActivityCategory>
    {
        public ActivityCategory(string name, int value, string displayName) : base(name, value, displayName)
        {

        }

        public static readonly ActivityCategory Meeting = new("Meeting", 1, "Toplantı");
        public static readonly ActivityCategory Seminar = new("Seminar", 2, "Seminer");
        public static readonly ActivityCategory Workshop = new("Workshop", 3, "Çalıştay");
        public static readonly ActivityCategory Training = new("Training", 4, "Eğitim");
    }
}