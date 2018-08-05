using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.OrderBC.Model;
using DddSob.DomainInfra.UnitOfWork;
using DddSob.Storage.Persistance.Nh.Core;
using DddSob.Storage.Persistance.Nh.NhRepository;
using NHibernate.Linq;

namespace DddSob.Contexts.NoRelation.Domain.Sagas.ShoppingSagas
{
    public interface ISagaRepository
        : IAsyncRepository
    {}
    

    public class ShoppingSagaRepository
    : NhAsyncRepository
    , ISagaRepository
    {
        private readonly INhSessionProvider _nhSessionProvider;
        public ShoppingSagaRepository(INhSessionProvider nhSessionProvider) 
            : base(nhSessionProvider) 
            => _nhSessionProvider = nhSessionProvider;

        public async Task<Result<ShoppingSagaData>> GetByOrderId(Guid orderId)
        {
            try
            {
                using (var session = _nhSessionProvider.OpenSession())
                {
                    return Result.Ok(
                        await session
                        .QueryOver<ShoppingSagaData>()
                        .Where(saga => saga.OrderSnapshot.Id == orderId)
                        .SingleOrDefaultAsync()
                    );
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<ShoppingSagaData>(ex.ToString());
            }
        }

        //public async Task<Result<ShoppingSagaData>> GetByOrderLineId(Guid orderLineId)
        //{
        //    try
        //    {
        //        using (var session = _nhSessionProvider.OpenSession())
        //        {
        //            return Result.Ok(
        //                await session
        //                .QueryOver<ShoppingSagaData>()
        //                .Where(saga => saga.OrderSnapshot.orderLine.Id == orderLineId))
        //                .SingleOrDefaultAsync()
        //            );
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Fail<ShoppingSagaData>(ex.ToString());
        //    }
        //}

        //public async Task<Result<OrderRoot>> GetOrder(Guid orderId)
        //{
        //    try
        //    {
        //        using (var session = _nhSessionProvider.OpenSession())
        //        {
        //            return Result.Ok(
        //                await session
        //                    .GetAsync<OrderRoot>(orderId)
        //            );
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Fail<OrderRoot>(ex.ToString());
        //    }
        //}

        //public async Task<Result<List<OrderLine>>> GetOrderLines(IList<Guid> orderlines)
        //{
        //    try
        //    {
        //        using (var session = _nhSessionProvider.OpenSession())
        //        {
        //            return Result.Ok(
        //                await session
        //                    .Query<OrderLine>()
        //                .Where(ol => orderlines.Any(id => id == ol.Id))
        //                .ToListAsync()
        //            );
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Fail<List<OrderLine>>(ex.ToString());
        //    }
        //}
    }
}
