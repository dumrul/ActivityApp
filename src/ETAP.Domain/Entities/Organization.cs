using Ardalis.GuardClauses;
using ETAP.Domain.Abstractions;
using ETAP.Domain.Entities.Identity;

namespace ETAP.Domain.Entities
{
    public sealed class Organization : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<AppUser> Users { get; set; } = new HashSet<AppUser>();
        public ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();

        private Organization() { }

        public Organization(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public void ChangeName(string newName)
        {
            Name = Guard.Against.NullOrWhiteSpace(newName, nameof(newName));
        }
    }
}