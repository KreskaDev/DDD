using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace DddSob.Messages.CQRS.Mediatr.Event
{
    public interface IHandlesEvent<in TEvent>
        where TEvent : INotification
    {
        //void Handle(TEvent message);

        //Event should not return Result, but we can log it!
        Task<Result> Handle(TEvent message);
    }
}