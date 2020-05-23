using Ofx.Battleship.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofx.Battleship.Domain.Aggregates.GameAggregate
{
    public class Ship : BaseEntity
    {
        //Ship size, default 1 X 1
        public int DimensionX { get; set; }

        public int DimensionY { get; set; }

        public Location Location { get; set; }

        public IList<ShipPart> ShipParts { get; set; }

        public Guid? PlayerId { get; set; }
        public Player Player { get; set; }

        public Ship()
        {
            DimensionX = 1;
            DimensionY = 1;
            Location = new Location(1, 1);
            InitiateLiveParts();
        }

        public Ship(int locationX, int locationY)
        {
            DimensionX = 1;
            DimensionY = 1;
            Location = new Location(locationX, locationY);
            CreatedByUsername = "Api test user";
            CreatedDateTime = DateTime.Now;
            InitiateLiveParts();
        }

        public Ship(int locationX, int locationY, int dimensionX, int dimensionY)
        {
            DimensionX = dimensionX;
            DimensionY = dimensionY;
            Location = new Location(locationX, locationY);
            InitiateLiveParts();
        }

        public bool OnAttack(Location location)
        {
            var response = false;
            var shipPart = ShipParts.FirstOrDefault(s => s.Location.X == location.X && s.Location.Y == location.Y && s.IsAlive);
            if (shipPart != null)
            {
                shipPart.Destroy();
                response = true;
            }

            return response;
        }

        private void InitiateLiveParts()
        {
            ShipParts = new List<ShipPart>();
            for (var x = 0; x <= DimensionX; x++)
            {
                for (var y = 0; y <= DimensionY; y++)
                {
                    ShipParts.Add(new ShipPart(new Location(Location.X + x, Location.Y + y)));
                }
            }
        }
    }
}
