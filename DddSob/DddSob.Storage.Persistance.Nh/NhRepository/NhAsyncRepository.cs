using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Storage.Persistance.Nh.Core;
using DddSob.Storage.Persistance.Nh.Model;

namespace DddSob.Storage.Persistance.Nh.NhRepository
{
    public class NhAsyncRepository
        : IAsyncRepository
    {
        private readonly INhSessionProvider _nhSessionProvider;

        public NhAsyncRepository(INhSessionProvider nhSessionProvider)
        {
            _nhSessionProvider = nhSessionProvider;
        }

        public virtual async Task<Result<TAggregateRoot>> Get<TAggregateRoot>(Guid identifier)
            where TAggregateRoot : NhAggregateRootEntity
        {
            try
            {
                using (var session = _nhSessionProvider.OpenSession())
                {
                    var result = await session.GetAsync<TAggregateRoot>(identifier);
                    return Result.Ok(result);
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<TAggregateRoot>(ex.ToString());
            }
        }

        public async Task<Result<TAggregateRoot>> Add<TAggregateRoot>(TAggregateRoot root)
            where TAggregateRoot : NhAggregateRootEntity
        {
            try
            {
                using (var session = _nhSessionProvider.OpenSession())
                {
                    await session.SaveAsync(root);
                    await session.FlushAsync();
                    return Result.Ok(root);
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<TAggregateRoot>(ex.ToString());
            }
        }

        public async Task<Result<TAggregateRoot>> Save<TAggregateRoot>(TAggregateRoot root) 
            where TAggregateRoot : NhAggregateRootEntity
        {
            try
            {
                using (var session = _nhSessionProvider.OpenSession())
                {
                    await session.SaveOrUpdateAsync(root);
                    await session.FlushAsync();
                    return Result.Ok(root);
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<TAggregateRoot>(ex.ToString());
            }
        }
    }
}
