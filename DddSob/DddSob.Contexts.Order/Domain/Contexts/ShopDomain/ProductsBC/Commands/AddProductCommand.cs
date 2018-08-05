using System;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Commands
{
    public class AddProductCommand 
        : IRequest<Result<Guid>>
    {
        public AddProductCommand(string name, decimal amount, Currency currency)
        {
            Name = name;
            Amount = amount;
            Currency = currency;
        }

        public string Name { get; }
        public decimal Amount { get; }
        public Currency Currency { get; }
    }
}