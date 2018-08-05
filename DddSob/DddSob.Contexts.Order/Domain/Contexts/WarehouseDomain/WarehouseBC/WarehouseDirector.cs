using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Model;
using DddSob.DomainInfra.UnitOfWork;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.WarehouseDomain.WarehouseBC
{
    public class WarehouseDirector
    {
        private readonly IUnitOfWork _unitOfWork;
        public WarehouseDirector(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<WarehouseRoot>> AddProductStock(Guid warehouseId, Product product, decimal amount)
            => await SnapProduct(product)
            .OnSuccess(productSnap => new ItemStockRoot(productSnap, amount))
            .OnSuccess(async itemSnap => await _unitOfWork
                .Get<WarehouseRoot>(warehouseId)
                .OnSuccess(warehouse => warehouse
                    .AddProductSnap(itemSnap)
                ).OnSuccess(async warehouse => await _unitOfWork.Compleate())
            );

        private async Task<Result<ItemStockRoot.WarehouseProductSnapshot>> SnapProduct(Product product)
            => await Task.FromResult(Result.Ok(
                new ItemStockRoot.WarehouseProductSnapshot
                {
                    Name = product.Name,
                    Price = product.Price,
                }
            ));

        public async Task<Result<WarehouseRoot>> AddWarehouse(string name)
            => await WarehouseRoot.Create(Guid.NewGuid(), name)
            .OnSuccess(async warehouse => await _unitOfWork.Add(warehouse))
            .OnSuccess(async warehouse => await _unitOfWork.Compleate());

    }
}