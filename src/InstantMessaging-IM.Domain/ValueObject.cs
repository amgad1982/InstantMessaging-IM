using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Domain;

public abstract class ValueObject<TKey> : IValueObject<TKey>
{
    public TKey Id { get; protected set; }
    public bool IsDeleted { get; private set; }
    public void Delete()
    {
        this.IsDeleted = true;
    }
    protected static bool EqualOperator(ValueObject<TKey> left, ValueObject<TKey> right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, right) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject<TKey> left, ValueObject<TKey> right)
    {
        return !(EqualOperator(left, right));
    }
    public static bool operator ==(ValueObject<TKey> one, ValueObject<TKey> two)
    {
        return EqualOperator(one, two);
    }

    public static bool operator !=(ValueObject<TKey> one, ValueObject<TKey> two)
    {
        return NotEqualOperator(one, two);
    }
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<TKey>)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x.GetHashCode())
            .Aggregate((x, y) => x ^ y);
    }


}
