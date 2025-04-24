using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace ETAP.Domain.Entities.Identity
{
    public sealed class AppRole : IdentityRole<Guid>
    {
        public const string Admin = "Admin";
        public const string Organizer = "Organizer";
        public const string Participant = "Participant";

        public string? Description { get; set; }

        // EF Core için parametresiz ctor
        public AppRole() : base()
        {
        }

        public AppRole(string roleName, string? description = null) : base(
            Guard.Against.NullOrWhiteSpace(roleName, nameof(roleName)))
        {
            var validRoles = new[] { Admin, Organizer, Participant };
            if (!validRoles.Contains(roleName))
            {
                throw new ArgumentException($"'{roleName}' geçerli bir rol değil. Sadece Admin, Organizer veya Participant olabilir.", nameof(roleName));
            }

            NormalizedName = roleName.ToUpperInvariant();
            Description = description;
        }
    }
}