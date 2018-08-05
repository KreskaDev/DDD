using System;

namespace DddSob.Contexts.NoRelation.Domain.Common.Services
{
    public interface ISystemTime
    {
        DateTime Now { get; }
    }
}