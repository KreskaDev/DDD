using System;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.DomainNoRules.Contexts;

namespace DddSob.Contexts.NoRelation.DomainNoRules.Services
{
    public class OrderSaga
    {
        private readonly IRepository _repository;

        public OrderSaga(IRepository repository)
        {
            _repository = repository;
        }

        public Result<long> StartOrder(Buyer buyer)
        => _repository.Add(new Order
        {
            Buyer = SnapBuyer(buyer),
            CreationDate = DateTime.UtcNow,
        });

        public Result<long> AddOrderLine(
            long orderId,
            Product product,
            int amount)
        => _repository.Add(new OrderLine(SnapProduct(product), amount));

        public Result FinalizeOrder(long orderId)
        {
            var order = _repository.Get<Order>(orderId);
            order.FinalizeOrder();
            return _repository.Save(order);
        }

        private BuyerSnapshot SnapBuyer(Buyer buyer)
        => new BuyerSnapshot
        {
            Name = buyer.Name,
            Address = buyer.Address,
            Nip = buyer.Nip
        };
        private ProductSnapshot SnapProduct(Product product)
        => new ProductSnapshot
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
}