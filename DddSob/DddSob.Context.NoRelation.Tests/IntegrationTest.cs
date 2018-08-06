using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.ErpDomain.CompanyBC;
using DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.ErpDomain.CompanyBC.Model;
using DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC.Commands;
using DddSob.Contexts.NoRelation.App.Domain._ExcludedDomains.IdmDomain.UsersBC.Model;
using FluentAssertions;
using MediatR;
using Xunit;

namespace DddSob.Context.NoRelation.Tests
{
    public class IntegrationTest : DatabaseTestBase
    {
        [Fact]
        public async void Execute()
        {
            var kreskadevId = await UserSimpleRegistrationUserStory("kreskadev@gmail.com", "1234");
            var piotrId = await UserSimpleRegistrationUserStory("piotr@rehafit.com", "1234");
            var aggaId = await UserSimpleRegistrationUserStory("agga@gmail.com", "1234");

            var rehafitId = await CreateCompanyUserStory(piotrId.Id, "Rehafit");
            var handmadeId = await CreateCompanyUserStory(aggaId.Id, "HandmadeMiracle");

            //var rehaFitShopId = await CreateShopUserStory(rehafitId, "");


            //var lukasId = await InviteUserStory(rehafitId, "lukas@rehafit.com");


            ShipmentCargoTraning();
        }

        private void ShipmentCargoTraning()
        {
            



        }

        private async Task<Company> CreateCompanyUserStory(Guid ownerId, string companyName)
        {
            var addCompanyRehafitResult = await Mediator
                .Send(new RegisterCompanyCommand(ownerId, companyName))
                .OnFailure(e => throw new Exception(e));

            addCompanyRehafitResult
                .IsSuccess.Should()
                .BeTrue();

            return addCompanyRehafitResult.Value;
        }

        private async Task<User> UserSimpleRegistrationUserStory(string email, string password)
        {
            var userRegistrationResult = await Mediator
                .Send(new RegisterUserCommand(email, password))
                .OnFailure(e => throw new Exception(e));

            userRegistrationResult
                .IsSuccess.Should()
                .BeTrue();

            var userEmailVerificationToken = await ReadModelOperations
                .GetMailVerificationTokenByUserId(userRegistrationResult.Value.Id)
                .OnFailure(e => throw new Exception(e));

            var userEmailVerificationResult = await Mediator
                .Send(new VerifyUserEmailCommand(userRegistrationResult.Value.Id, userEmailVerificationToken.Value));

            userEmailVerificationResult
                .IsSuccess.Should()
                .BeTrue();

            return userRegistrationResult.Value;
        }

        //private async Task<Guid> CreateShopUserStory(Guid rehafitId, string companyName)
        //{
        //    var shopId = await Mediator
        //        .Send(new CreateShopCommand(rehafitId, companyName));

        //    var toyResult = await Mediator
        //        .Send(new AddProductCommand("Toy", 10, Currency.Pln));
        //    toyResult.IsSuccess.Should().BeTrue();

        //    return shopId.Value;
        //}

        //public void MakeOrders()
        //{
        //    //var repResult = await _contractorsDirector
        //    //    .AddContractor("Red eye piranhas", "23482359872983", "address");
        //    //repResult.IsSuccess.Should().BeTrue();

        //    ////UserStory
        //    //var newOrderResult = await _shopDirector
        //    //    .PlaceNewOrder(repResult.Value);
        //    //newOrderResult.IsSuccess.Should().BeTrue();

        //    //var addOrderLineResult = await _shopDirector
        //    //    .AddOrderLine(newOrderResult.Value, toyResult.Value, 10);
        //    //addOrderLineResult.IsSuccess.Should().BeTrue();

        //    //var finalizeOrderResult = await _shopDirector
        //    //    .FinalizeOrder(newOrderResult.Value);
        //    //finalizeOrderResult.IsSuccess.Should().BeTrue();

        //    ////check read model
        //    //var totalAmount = _readModelOperations
        //    //    .GetBuyerTotalPaidAmount(repResult.Value);
        //    //totalAmount.Should().Be(100);
        //}

        

        //private async Task<Guid> InviteUserStory(Guid companyId, string email)
        //{
        //    var userInvitationResult = await Mediator
        //        .Send(new InviteUserCommand(companyId, email));
        //    userInvitationResult.IsSuccess.Should().BeTrue();

        //    var invitedUserId = await ReadModelOperations
        //        .GetUserIdByEmail(email);

        //    //await _userService.AcceptInvitation(invitedUserId, )


        //    return userInvitationResult.Value;
        //}



    }

    //public class UserSimpleRegistrationUserStory
    //{

    //}
}
