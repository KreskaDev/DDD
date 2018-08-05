using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;

namespace DddSob.Contexts.NoRelation.BussinesLogic
{
    public interface ITaxCalculatror
    {
        Task<Result<Money>> CalculateTaxes(Money amount);
    }
}