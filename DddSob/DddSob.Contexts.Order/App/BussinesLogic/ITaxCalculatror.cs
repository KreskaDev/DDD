using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.App.Domain.Common.Models;

namespace DddSob.Contexts.NoRelation.App.BussinesLogic
{
    public interface ITaxCalculatror
    {
        Task<Result<Money>> CalculateTaxes(Money amount);
    }
}