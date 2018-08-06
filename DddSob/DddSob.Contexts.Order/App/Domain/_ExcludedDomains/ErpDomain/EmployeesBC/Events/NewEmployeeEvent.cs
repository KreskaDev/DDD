using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.EmployeesBC.Events
{
    public class NewEmployeeEvent : INotification
    {
        public Guid Id { get; }
        public Guid CompanyId { get; }
        public Guid UserId { get; }

        public NewEmployeeEvent(Guid id, Guid companyId, Guid userId)
        {
            Id = id;
            CompanyId = companyId;
            UserId = userId;
        }
    }
}