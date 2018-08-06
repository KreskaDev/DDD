using DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC.Model;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC
{
    public class UserMappings 
        : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.Id(user => user.Id);

            mapping
                .References(x => x.Email)
                .Unique()
                .Cascade
                .All()
                .Not
                .LazyLoad();
        }
    }
}
