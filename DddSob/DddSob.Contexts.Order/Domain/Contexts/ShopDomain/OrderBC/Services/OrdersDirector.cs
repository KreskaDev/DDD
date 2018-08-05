using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.BussinesLogic;
using DddSob.Contexts.NoRelation.Domain.Common.Services;
using DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Model;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Model;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Model;
using DddSob.DomainInfra.UnitOfWork;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Services
{
    public class OrdersDirector
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncRepository _repository;

        private readonly ITaxCalculatror _taxCalculatror;
        private readonly ISystemTime _systemTime;

        public OrdersDirector(
            IUnitOfWork unitOfWork, 
            IAsyncRepository repository, 
            ITaxCalculatror taxCalculatror, 
            ISystemTime systemTime)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _taxCalculatror = taxCalculatror;
            _systemTime = systemTime;
        }

        
        public Task<Result<OrderRoot>> PlaceNewOrder(Guid customerId)
            => _repository
            .Get<Contractor>(customerId)
            .OnSuccess(customer => SnapBuyer(customer))
            .OnSuccess(buyerSnapshot => OrderRoot.Create(Guid.NewGuid(), buyerSnapshot, _systemTime.Now))
            .OnSuccess(orderRoot => _unitOfWork.Add(orderRoot))
            .OnSuccess(orderId => _unitOfWork.Compleate());

        private async Task<Result<Customer>> SnapBuyer(Contractor contractor)
            => Result.Ok(new Customer
            {
                Name = contractor.Name,
                //Address = contractor.Address,
                //Nip = contractor.Nip
            });

        public Task<Result<OrderLine>> AddOrderLine(Guid orderId, Guid productId, decimal amount)
            => _repository
                .Get<Product>(productId)
                .OnSuccess(product => SnapProduct(product))
                .OnSuccess(product => OrderLine.Create(Guid.NewGuid(), orderId, product, amount))
                .OnSuccess(orderLine => _unitOfWork.Add(orderLine))
                .OnSuccess(orderLineId => _unitOfWork.Compleate());

        private async Task<Result<OrderLineProductSnapshot>> SnapProduct(Product product)
            => Result.Ok(new OrderLineProductSnapshot
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });

        public async Task<Result> FinalizeOrder(Guid orderId)
            => await _repository
                .Get<OrderRoot>(orderId)
                .OnSuccess(orderRoot => orderRoot.FinalizeOrder())
                .OnSuccess(orderRoot => _repository.Save(orderRoot));
    }
}
