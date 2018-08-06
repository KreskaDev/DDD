using CSharpFunctionalExtensions;
using DddSob.DomainInfra.Model;

namespace DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC.Model
{
    public class Email 
        : AggregateEntity
    {
        protected Email()
        { }

        public Email(string address, string verificationToken)
        {
            Address = address;
            VerificationToken = verificationToken;
            IsVerified = false;
        }

        public virtual string Address { get; protected set; }
        public virtual bool IsVerified { get; protected set; }
        public virtual string VerificationToken { get; protected set; }

        public virtual Result Verify(string token)
        {
            if (VerificationToken != token)
            {
                return Result.Fail("Invalid token");
            }

            IsVerified = true;
            return Result.Ok();
        }
    }
}