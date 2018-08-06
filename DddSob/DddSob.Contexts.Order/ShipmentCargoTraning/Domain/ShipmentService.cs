using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.ShipmentCargoTraning.Domain.Model;
using DddSob.DomainInfra.UnitOfWork;
using MediatR;

namespace DddSob.Contexts.NoRelation.ShipmentCargoTraning.Domain
{
    public class ShipmentService
        : IRequestHandler<RegisterNewShipCommand, Result<Ship>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Ship>> Handle(RegisterNewShipCommand request, CancellationToken cancellationToken) 
            => await Ship
            .Create(request.Name)
            .OnSuccess(ship => _unitOfWork.Add(ship))
            .OnSuccess(ship => _unitOfWork.Compleate());
    }
}
