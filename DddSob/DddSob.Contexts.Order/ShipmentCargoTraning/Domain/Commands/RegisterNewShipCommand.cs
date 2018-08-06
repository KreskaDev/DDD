using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.ShipmentCargoTraning.Domain.Model;
using MediatR;

namespace DddSob.Contexts.NoRelation.ShipmentCargoTraning.Domain
{
    public class RegisterNewShipCommand
        : IRequest<Result<Ship>>
    {
        public string Name { get; set; }
    }
}