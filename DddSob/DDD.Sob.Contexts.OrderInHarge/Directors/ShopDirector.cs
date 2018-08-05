using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.DomainNoRules.Contexts;
using DddSob.Contexts.NoRelation.DomainNoRules.Services;

namespace DddSob.Contexts.NoRelation.Directors
{
    public class ShopDirector
    {
        private readonly IRepository _repository;
        private readonly OrderSaga _orderSaga;

        public ShopDirector(OrderSaga orderSaga)
        {
            _orderSaga = orderSaga;
        }

        public void AddProductCommand()
        {
            
        }

        public void AddBuyerCommand()
        {

        }

        public Result<long> PlaceNewOrder(long buyerId)
        {

            var buyer = _repository.Get<Buyer>(buyerId);


            return _orderSaga.StartOrder(buyer);
        }

        public void AddOrderLine()
        {

        }

        public void FinalizeOrder()
        {

        }
    }
}