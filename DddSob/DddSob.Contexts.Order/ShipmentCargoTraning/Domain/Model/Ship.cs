using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DddSob.DomainInfra.Model;

namespace DddSob.Contexts.NoRelation.ShipmentCargoTraning.Domain.Model
{
    public class Ship
        : AggregateRootEntity
    {
        public static async Task<Result<Ship>> Create(string name)
            => Result.Ok(new Ship(new NewShipEvent()
            {
                Name = name
            }));

        protected Ship(NewShipEvent notification)
            : this()
            => ApplyChange<Ship>(notification);
        

        protected Ship()
        {
            Register<NewShipEvent>(When);
        }

        private void When(NewShipEvent notification)
        {
            Name = notification.Name;
        }

        public virtual string Name { get; set; }
    }
}
