using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using ETAP.Domain.Common.Guards;
using Microsoft.AspNetCore.Identity;

namespace ETAP.Domain.Entities.Identity
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        // Navigations
        public ICollection<Activity> OrganizedActivities { get; set; } = new List<Activity>();
        public ICollection<ActivityParticipant> ParticipatedActivities { get; set; } = new List<ActivityParticipant>();
        public Guid? OrganizationId { get; set; }
        public Organization? Organization { get; set; }

        private AppUser() { }

        public AppUser(string firstName, string lastName, string email)
        {
            FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
            Email = Guard.Against.InvalidEmail(email, nameof(email));
            UserName = email;
        }

        public void ChangeEmail(string newEmail)
        {
            Email = Guard.Against.InvalidEmail(newEmail, nameof(newEmail));
            UserName = Email;
        }
    }
}