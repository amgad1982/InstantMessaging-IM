namespace InstantMessaging_IM.Domain;

public interface IEntityBase<Tkey>
{
    Tkey Id { get; }

}
public interface IValueObject<Tkey>
{
    Tkey Id { get; }
    bool IsDeleted { get; }
    void Delete();
}

public interface IAuditableEntityBase<Tkey, TKUser> : IEntityBase<Tkey>
{
    DateTime? Updated { get; }
    DateTime Created { get; }
    TKUser UpadatedBy { get; }
    void SetCreated(TKUser userId, DateTime crearted);
    void SetUpdated(TKUser userId, DateTime updated);

}

public abstract class Entity<Tkey> : IEntityBase<Tkey>
{
    protected Entity()
    {

    }
    public Tkey Id { get; protected set; }
    public bool IsDeleted { get; private set; }
    public void Delete()
    {
        IsDeleted = true;
    }
}


public abstract class AuditableEntityBase<Tkey, TKUser>
: Entity<Tkey>, IAuditableEntityBase<Tkey, TKUser>
{
    protected AuditableEntityBase()
    {
    }


    public DateTime? Updated { get; protected set; }
    public DateTime Created { get; protected set; }
    public TKUser UpadatedBy { get; protected set; }
    public void SetCreated(TKUser userId, DateTime created)
    {
        this.Created = created;
        this.UpadatedBy = userId;
    }

    public void SetUpdated(TKUser userId, DateTime updated)
    {
        this.Updated = updated;
        this.UpadatedBy = userId;
    }


}
