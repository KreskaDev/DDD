using DddSob.Contexts.NoRelation.Common;
using DddSob.Contexts.NoRelation.Directors;
using DddSob.Contexts.NoRelation.DomainNoRules.Contexts;
using DddSob.Contexts.NoRelation.DomainNoRules.Services;
using NSubstitute;
using Xunit;

namespace DddSob.Contexts.NoRelation.Tests
{
    public class IntegrationTest
    {
        public readonly ShopDirector ShopDirector = new ShopDirector();

        private readonly IRepository _repository
            = Substitute.For<IRepository>();

        public static Product Toy = new Product
        {
            Id = 1,
            Name = "Toy",
            Price = new Money { Amount = 10, Currency = Currency.Pln }
        };

        public static Buyer RedEyePiranhas = new Buyer
        {
            Name = "Red eye piranhas",
            Address = "address",
            Nip = "23482359872983"
        };


        [Fact]
        public void Execute()
        {
            var shop = new OrderSaga(_repository);
            var newOrderResult = shop.StartOrder(RedEyePiranhas);

            shop.AddOrderLine(
                newOrderResult.Value,
                Toy,
                10
            );

            shop.FinalizeOrder(newOrderResult.Value);

            //var invoice = 
            //invoice.TotalAmount.Should().Be(100);
        }

        public void MakeShop()
        {
            
        }
    }
}
