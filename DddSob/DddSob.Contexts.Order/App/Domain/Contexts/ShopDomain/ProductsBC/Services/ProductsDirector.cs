using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Commands;
using DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Model;
using DddSob.DomainInfra.UnitOfWork;
using DddSob.Storage.Persistance.Nh.NhRepository;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.ShopDomain.ProductsBC.Services
{
    public class ProductsDirector
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public ProductsDirector(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


        public async Task<Result<Product>> AddProduct(AddProductCommand command)
        => await Product.Register(Guid.NewGuid(), command.Name, new Money(command.Amount, command.Currency))
            .OnSuccess(product => _unitOfWork.Add(product))
            .OnSuccess(product => _unitOfWork.Compleate());


        //public async Task<Result<Guid>> AddProduct(AddProductCommand command)
        //    => await _mediator.Send(new command.Name, new Money(command.Amount, command.Currency))
        //        .OnSuccess(async product => await _unitOfWork.Compleate());


    }
}