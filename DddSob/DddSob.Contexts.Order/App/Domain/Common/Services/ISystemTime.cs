using System;

namespace DddSob.Contexts.NoRelation.App.Domain.Common.Services
{
    public interface ISystemTime
    {
        DateTime Now { get; }
    }
}