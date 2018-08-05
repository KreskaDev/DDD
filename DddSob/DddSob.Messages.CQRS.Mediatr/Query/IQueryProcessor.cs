using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace DddSob.Messages.CQRS.Mediatr.Query
{
    public interface IQueryProcessor
    {
        Task<Result<TResult>> Query<TResult, TQueryFilter>(TQueryFilter filter);
    }
}