using Ofx.Battleship.Domain.Common;
using System;

namespace Ofx.Battleship.Domain.Aggregates.GameAggregate
{
    public class ShipPart : BaseEntity
    {
        public Location Location { get; private set; }

        public bool IsAlive { get; private set; }

        public Guid? ShipId { get; set; }

        public Ship Ship { get; set; }

        public ShipPart()
        {

        }

        public ShipPart(Location location)
        {
            Location = location;
            IsAlive = true;
        }

        public void Destroy()
        {
            IsAlive = false;
        }
    }
}
