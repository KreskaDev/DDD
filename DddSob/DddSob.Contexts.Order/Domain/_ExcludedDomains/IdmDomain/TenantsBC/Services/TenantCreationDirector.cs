using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.TenantsBC.Services
{
    public class TenantDirector
    {
        public async Task<Result<Guid>> CreateTenant()
        {
            return Result.Fail<Guid>("Not implemented");
        }

    }
}
