using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.App.Domain.Common.Models;

namespace DddSob.Contexts.NoRelation.App.BussinesLogic
{
    public class TaxCalculatror
        : ITaxCalculatror
    {
        private readonly decimal _tax = 1.10m;

        public async Task<Result<Money>> CalculateTaxes(Money amount)
        {
            if (amount.Amount == 0)
            {
                return Result.Fail<Money>("Cannot calculate tax from 0 amount");
            }
                
            return Result.Ok(new Money
            (
                amount.Amount * _tax,
                amount.Currency
            ));
        }
    }
}