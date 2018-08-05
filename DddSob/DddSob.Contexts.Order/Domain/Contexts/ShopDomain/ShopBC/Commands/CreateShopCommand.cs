using System;
using CSharpFunctionalExtensions;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ShopBC.Commands
{
    public class CreateShopCommand : IRequest<Result<Guid>>
    {
        public Guid RehafitId { get; }
        public string CompanyName { get; }

        public CreateShopCommand(Guid rehafitId, string companyName)
        {
            RehafitId = rehafitId;
            CompanyName = companyName;
        }
    }
}