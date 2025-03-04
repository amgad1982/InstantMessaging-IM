namespace InstantMessaging_IM.Domain
{
    public abstract class Entity<TIdentity>
    {
        public required TIdentity Id { get; init; }
    }

    public abstract class AuditEntity<TIdentity> : Entity<TIdentity>
    {
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
