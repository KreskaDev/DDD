using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.BussinesLogic;
using DddSob.Contexts.NoRelation.Domain.Common.Services;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Commands;
using DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Model;
using DddSob.DomainInfra.UnitOfWork;
using DddSob.Storage.Persistance.Nh.NhRepository;
using MediatR;

namespace DddSob.Contexts.NoRelation.Domain._ExcludedDomains.IdmDomain.UsersBC.Services
{
    public class UserRegistrationDirector
        : IRequestHandler<RegisterUserCommand, Result<User>>
        , IRequestHandler<VerifyUserEmailCommand, Result<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailVerificationTokenGenerator _generator;
        private readonly ISystemTime _systemTime;

        public UserRegistrationDirector(
            IUnitOfWork unitOfWork, 
            IEmailVerificationTokenGenerator generator, 
            ISystemTime systemTime)
        {
            _unitOfWork = unitOfWork;
            _generator = generator;
            _systemTime = systemTime;
        }
        public Task<Result<User>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
            => _generator.GenerateToken(new { command.Email, _systemTime.Now })
            .OnSuccess(token => User.Register(command.Email, command.Password, token))
            .OnSuccess(async user => await _unitOfWork.Add(user))
            .OnSuccess(async user => await _unitOfWork.Compleate());

        public Task<Result<User>> Handle(VerifyUserEmailCommand command, CancellationToken cancellationToken)
            => _unitOfWork
            .Get<User>(command.UserId)
            .OnSuccess(user => user.CompleateRegistration(command.VerificationToken))
            .OnSuccess(async user => await _unitOfWork.Compleate());
    }
}