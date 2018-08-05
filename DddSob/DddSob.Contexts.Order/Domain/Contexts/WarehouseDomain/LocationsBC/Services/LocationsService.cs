using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.WarehouseDomain.LocationsBC.Model;
using DddSob.DomainInfra.UnitOfWork;
using DddSob.Storage.Persistance.Nh.NhRepository;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.WarehouseDomain.LocationsBC.Services
{
    public class LocationsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Location>> Get(Guid locationId)
            => await _unitOfWork.Get<Location>(locationId);

        public async Task<Result<Location>> Add(string country, string street, string number, string zipCode)
        => await Location.Register(Guid.NewGuid(), country, street, number, zipCode)
        .OnSuccess(async location => await _unitOfWork.Add(location))
        .OnSuccess(async location => await _unitOfWork.Compleate());
    }
}
