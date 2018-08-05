using CSharpFunctionalExtensions;
using DddSob.Storage.Persistance.Nh.Relations;

namespace DddSob.Storage.Persistance.Nh.Model
{
    //public abstract class NhValueObject<T>
    //    : IEntity
    //    where T 
    //        : NhValueObject<T>
    //{
    //    public override bool Equals(object obj)
    //    {
    //        var valueObject = obj as T;

    //        if (ReferenceEquals(valueObject, null))
    //            return false;

    //        if (GetType() != obj.GetType())
    //            return false;

    //        return EqualsCore(valueObject);
    //    }

    //    protected abstract bool EqualsCore(T other);

    //    public override int GetHashCode()
    //    {
    //        return GetHashCodeCore();
    //    }

    //    protected abstract int GetHashCodeCore();

    //    public static bool operator ==(NhValueObject<T> a, NhValueObject<T> b)
    //    {
    //        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
    //            return true;

    //        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
    //            return false;

    //        return a.Equals(b);
    //    }

    //    public static bool operator !=(NhValueObject<T> a, NhValueObject<T> b)
    //    {
    //        return !(a == b);
    //    }
    //}
}