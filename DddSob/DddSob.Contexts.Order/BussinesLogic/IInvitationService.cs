using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace DddSob.Contexts.NoRelation.BussinesLogic
{
    public interface IInvitationService
    {
        Task<Result> Invite(string email);
    }
    
    //public class InvitationService : IInvitationService
    //{
    //    private ISmtpClient _client;

    //    public Task<Result> Invite(string email)
    //    {
    //        return _client.Sent();
    //    }
    //}
}