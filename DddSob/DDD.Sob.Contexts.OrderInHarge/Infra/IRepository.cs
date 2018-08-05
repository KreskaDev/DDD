using CSharpFunctionalExtensions;

namespace DddSob.Contexts.NoRelation.DomainNoRules.Services
{
    public interface IRepository
    {
        Result<long> Add<TType>(TType aggregate);
        Result Save<TType>(TType aggregate);
        TType Get<TType>(long id);
    }
}