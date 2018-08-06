using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.EmployeesBC.Events;
using DddSob.DomainInfra.Aggregates;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.ErpDomain.EmployeesBC.Model
{
    public class Employee
        : AggregateRootEntity
    {
        public async static Task<Result<Employee>> Create(Guid id, Guid companyId, Guid userId)
            => IsValid()
            ? Result.Ok(new Employee(new NewEmployeeEvent(id, companyId, userId)))
            : Result.Fail<Employee>("");

        private static bool IsValid() => true;

        public Employee(NewEmployeeEvent message)
        {
            ApplyChange<Employee>(message);
        }

        public Guid UserId { get; protected set; }
        public Guid CompanyId { get; protected set; }

        protected Employee()
        {
            Register<NewEmployeeEvent>(When);
        }

        private void When(NewEmployeeEvent message)
        {
            Id = message.Id;
            CompanyId = message.CompanyId;
            UserId = message.UserId;
        }
    }
}
