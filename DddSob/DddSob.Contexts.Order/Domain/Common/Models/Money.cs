using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace DddSob.Contexts.NoRelation.Domain.Common.Models
{
    public class Money : ValueObject
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected Money()
        {
        }

        public static Money operator +(Money money, Money other)
        {
            if (money.Currency != other.Currency)
            {
                throw new Exception();
            }

            return new Money(
                money.Amount, 
                money.Currency
            );
        }

        public static Money operator *(Money money, decimal amount) 
            => new Money(
                money.Amount * amount,
                money.Currency
            );

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}