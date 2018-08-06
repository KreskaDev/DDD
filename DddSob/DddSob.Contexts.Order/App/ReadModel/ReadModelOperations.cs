using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC.Model;
using DddSob.Storage.Persistance.Nh.Core;

namespace DddSob.Contexts.NoRelation.App.ReadModel
{
    public interface IReadModelOperations
    {
        decimal? GetBuyerTotalPaidAmount(Guid buyerId);
        Task<Result<string>> GetMailVerificationTokenByUserId(Guid value);
        Task<Result<Guid>> GetUserIdByEmail(string email);
    }

    public class ReadModelOperations : IReadModelOperations
    {
        private readonly INhSessionProvider _sessionProvider;

        public ReadModelOperations(INhSessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public decimal? GetBuyerTotalPaidAmount(Guid buyerId)
        {
            //var result = _session
            //    .QueryOver<>()
            return null;
        }

        public async Task<Result<string>> GetMailVerificationTokenByUserId(Guid value)
        {
            try
            {
                //stateless session should be ussed by feath problems
                using (var session = _sessionProvider.OpenSession())
                {
                    return Result.Ok(
                        //(await session
                        //    .Query<User>()
                        //    .Fetch(x => x.Email)
                        //    .SingleOrDefaultAsync())
                        session
                            .Get<User>(value)
                            .Email
                            .VerificationToken
                    );
                }
            }
            catch (Exception e)
            {
                return Result.Fail<string>(e.ToString());
            }
        }

        public async Task<Result<Guid>> GetUserIdByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }

    public class MailValidationList
    {

    }
}