using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace DddSob.Messages.CQRS.Mediatr.Command
{
    public interface ICommandHandler<in TCommand>
        where TCommand : IRequest
    {
        bool Validate(TCommand message);
        Task<Result> Handle(TCommand message);
    }
}