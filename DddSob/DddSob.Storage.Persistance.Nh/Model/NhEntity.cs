using System;
using DddSob.Storage.Persistance.Nh.Relations;
using NHibernate.Proxy;

namespace DddSob.Storage.Persistance.Nh.Model
{
    //TODO-extrakr NhEntity should inhert from language extensions Record class
    public abstract class NhEntity<TKey>
        : IEntity
        where TKey
            : IEquatable<TKey>
    {
        public virtual TKey Id { get; protected set; }

        public virtual bool Equals(NhEntity<TKey> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var thisType = (this is INHibernateProxy) ? GetType().BaseType : GetType();
            var otherType = (other is INHibernateProxy) ? other.GetType().BaseType : other.GetType();

            if (thisType != otherType)
            {
                return false;
            }

            return !Id.Equals(default(TKey)) && !other.Id.Equals(default(TKey)) && other.Id.Equals(Id);
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals(obj as NhEntity<TKey>);
        }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
