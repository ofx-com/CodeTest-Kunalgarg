using MediatR;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;

namespace Ofx.Battleship.Domain.Events
{
    public class PlayerFiredDomainEvent : INotification
    {
        public Player SourcePlayer { get; private set; }

        public Location TargetLocation { get; private set; }

        public PlayerFiredDomainEvent(Location targetLocation)
        {
            TargetLocation = targetLocation;
        }
    }
}
