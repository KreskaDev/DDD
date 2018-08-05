using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.Domain.Common.Models;
using DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Model;
using DddSob.DomainInfra.UnitOfWork;

namespace DddSob.Contexts.NoRelation.Domain.Contexts.SalesDomain.PaymentsBC.Services
{
    public class PaymentDirector
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentDirector(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public Task<Result<Account>> AddAccount(Guid userId) 
            => Account
            .Create(Guid.NewGuid(), userId)
            .OnSuccess(account => _unitOfWork.Add(account))
            .OnSuccess(account => _unitOfWork.Compleate());

        public Task<Result<Account>> AddFounds(Guid accountId, decimal amount, Currency currency) 
            => _unitOfWork
            .Get<Account>(accountId)
            .OnSuccess(account => account.AddFounds(new Money(amount, currency)))
            .OnSuccess(account => _unitOfWork.Compleate());

        public Task<Result<Payment>> MakePayment(Guid payerId, decimal amount, Currency currency)
            => Payment
            .ScheadulePayment(Guid.NewGuid(), payerId, new Money(amount, currency))
            .OnSuccess(payment => _unitOfWork.Add(payment))
            .OnSuccess(payment => _unitOfWork.Compleate());



    }
}
