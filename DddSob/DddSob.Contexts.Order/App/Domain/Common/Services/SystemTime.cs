using System;

namespace DddSob.Contexts.NoRelation.App.Domain.Common.Services
{
    public class SystemTime : ISystemTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}