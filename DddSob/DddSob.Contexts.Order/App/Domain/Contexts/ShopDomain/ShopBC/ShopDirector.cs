using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.DomainInfra.UnitOfWork;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ShopBC
{
    public class ShopDirector
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopDirector(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<Shop>> CreateShop(Guid companyId, string name)
            => await Shop.Create(Guid.NewGuid(), companyId, name)
                .OnSuccess(async shop => await _unitOfWork.Add(shop))
                .OnSuccess(async shop => await _unitOfWork.Compleate());

    }
}