using System;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Events
{
    public struct NewContractorEvent : INotification
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Nip { get; }
        public string Address { get; }

        public NewContractorEvent(
            Guid id,
            string name,
            string nip,
            string address)
        {
            Id = id;
            Name = name;
            Nip = nip;
            Address = address;
        }
    }
}