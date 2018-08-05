using System;
using System.Threading;
using System.Threading.Tasks;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.TenantsBC.Events;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.Sagas
{
    public class TenantUserLifetimeSaga
        : INotificationHandler<UserInvitedToTenantEvent>
    {
        public Task Handle(UserInvitedToTenantEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
