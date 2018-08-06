using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace DddSob.Contexts.NoRelation.App.BussinesLogic
{
    public interface IEmailVerificationTokenGenerator
    {
        Task<Result<string>> GenerateToken(object sth);
    }

    public class EmailVerificationTokenGenerator 
        : IEmailVerificationTokenGenerator
    {
        public async Task<Result<string>> GenerateToken(object sth) 
            => Result.Ok(Guid.NewGuid().ToString());
    }
}