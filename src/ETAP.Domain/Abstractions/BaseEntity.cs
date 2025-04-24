namespace ETAP.Domain.Abstractions
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}