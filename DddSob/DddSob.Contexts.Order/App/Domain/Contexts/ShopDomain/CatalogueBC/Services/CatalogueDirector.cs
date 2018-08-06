using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Model;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Model;
using DddSob.DomainInfra.UnitOfWork;
using DddSob.Storage.Persistance.Nh.NhRepository;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.CatalogueBC.Services
{
    public class CatalogueDirector
        : IRequestHandler<AddProductToCategoryCommand>
    {
        private readonly IAsyncRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CatalogueDirector(
            IAsyncRepository repository, 
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Catalogue>> AddCatalogue(string name)
        => await Catalogue.Create(name)
            .OnSuccess(catalogue => _unitOfWork.Add(catalogue))
            .OnSuccess(catalogue => _unitOfWork.Compleate());

        public async Task<Result<Catalogue>> AddCategory(string name)
            => await Catalogue.Create(name)
            .OnSuccess(category => _unitOfWork.Add(category))
            .OnSuccess(categoryId => _unitOfWork.Compleate());
        
        public async Task Handle(AddProductToCategoryCommand request, CancellationToken cancellationToken)
            => await _unitOfWork
            .Get<Product>(request.ProductId)
            //.Map()
            .OnSuccess(product => _unitOfWork
                .Get<Catalogue>(request.CatalogueId)
                .OnSuccess(catalogue => catalogue.AddProduct(request.CategoryId, product))
                .OnSuccess(catalogue => _repository.Save(catalogue))
            )
            .OnSuccess(product => _unitOfWork.Compleate());
        
    }

    public class AddProductToCategoryCommand
        : IRequest
    {
        public Guid CatalogueId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
    }
}
