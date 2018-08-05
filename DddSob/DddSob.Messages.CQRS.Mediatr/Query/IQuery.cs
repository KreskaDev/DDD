using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace DddSob.Messages.CQRS.Mediatr.Query
{
    public interface IQuery<TResult, in TQueryFilter>
    {
        Result Validate(TQueryFilter filter);
        Task<Result<TResult>> Query(TQueryFilter filter);
    }
}