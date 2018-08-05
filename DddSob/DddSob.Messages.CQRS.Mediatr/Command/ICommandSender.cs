using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace DddSob.Messages.CQRS.Mediatr.Command
{
    public interface ICommandSender
    {
        Task<Result> Send<TMessage>(TMessage command)
            where TMessage : IRequest;
    }
}