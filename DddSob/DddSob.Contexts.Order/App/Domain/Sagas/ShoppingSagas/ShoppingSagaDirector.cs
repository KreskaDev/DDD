//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using CSharpFunctionalExtensions;
//using DddSob.Contexts.NoRelation.BussinesLogic;
//using DddSob.Contexts.NoRelation.Domain.Common.Models;
//using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Events;
//using MediatR;

//namespace DddSob.Contexts.NoRelation.Domain.Sagas.ShoppingSagas
//{
//    public class ShoppingSagaDirector
//    : INotificationHandler<NewOrderEvent>
//    {
//        private readonly ShoppingSagaRepository _sagaRepository;
//        private readonly ITaxCalculatror _taxCalculatror;
        
//        public ShoppingSagaDirector( 
//            ShoppingSagaRepository sagaRepository, 
//            ITaxCalculatror taxCalculatror)
//        {
//            _sagaRepository = sagaRepository;
//            _taxCalculatror = taxCalculatror;
//        }
//        public Task Handle(NewOrderEvent notification, CancellationToken cancellationToken)
//            => await ShoppingSagaData
//                .Create(Guid.NewGuid(), notification.OrderId)
//                .OnSuccess(sagaData => _sagaRepository.Add(sagaData));
            

//        //public async Task<Result> Handle(NewOrderLineEvent @event)
//        //    => await _sagaRepository
//        //    .GetByOrderId(@event.OrderId)
//        //    .OnSuccess(sagaData => sagaData.OrderSnapshot.Id@event.OrderLineId))
//        //    .OnSuccess(sagaData => _sagaRepository.Save(sagaData));

//        public async void Handle(OrderFinalizedEvent @event)
//            => await _sagaRepository.GetByOrderId(@event.OrderId)
//                .OnSuccess(sagaData => FinalizeOrder(sagaData))
//                .OnSuccess(sagaData => _sagaRepository.Save(sagaData));

//        private async Task<ShoppingSagaData> FinalizeOrder(ShoppingSagaData sagaData)
//        {
//            var order = await _sagaRepository
//                .GetOrder(sagaData.OrderId);

//            if (order.IsFailure)
//            {
                
//            }

//            var orderLines = await _sagaRepository
//                .GetOrderLines(sagaData.OrderLines);

//            if(orderLines.IsFailure)
//            {

//            }

//            var totalAmount = orderLines
//                .Value
//                .Aggregate(
//                    new Money(0, Currency.Pln), 
//                    (x, y) => x + (y.Product.Price * y.Amount)
//                );

//            var taxAmount = await _taxCalculatror
//                .CalculateTaxes(totalAmount);



//            return null;
//        }

//        private void CompleateIfPossible()
//        {

//        }

//        //public async Task<Result> Create(long orderId)
//        //public async Task<Result<long>> PlaceNewOrder(long buyerId)
//        //    => await _sagaRepository.Get<Contractor>(buyerId)
//        //        .OnSuccess(buyer => _orderService.StartOrder(buyer))
//        //        .OnSuccess(async order => await _sagaRepository.Add(order))
//        //;

//        //public async Task<Result> OrderLineAdded(long orderId, long orderLineId)
//        //public async Task<Result<long>> AddOrderLine(long orderId, int productId, decimal amount)
//        //    => await _sagaRepository.Get<Product>(productId)
//        //        .OnSuccess(product => _orderLineService.AddOrderLine(orderId, product, amount))
//        //        .OnSuccess(async orderLine => await _sagaRepository.Add(orderLine))
//        //;

//        //public async Task OrderFinalizedEventHandler(OrderFinalized @event)

//        //public async Task<Result> FinalizeOrder(long orderId)
//        //{
//        //    var sagaData = await _sagaRepository.Get<ShoppingSagaData>(999999);

//        //    if (sagaData.IsFailure)
//        //    {
//        //        return Result.Fail("");
//        //    }

//        //    var orderResult = await _sagaRepository.Get<OrderRoot>(orderId);
//        //    var orderLinesResult = await Task.WhenAll(
//        //        sagaData
//        //            .Value
//        //            .OrderLines
//        //            .Select(async orderlineId => await _sagaRepository.Get<OrderLine>(orderlineId))
//        //    );

//        //    if (orderResult.IsFailure || Result.Combine(orderLinesResult).IsFailure)
//        //    {
//        //        return Result.Fail("");
//        //    }

//        //    return await _orderService.FinalizeOrder(
//        //        orderResult.Value,
//        //        orderLinesResult
//        //            .Select(x => x.Value)
//        //            .ToArray()
//        //    );
//        //}
        
//    }
//}