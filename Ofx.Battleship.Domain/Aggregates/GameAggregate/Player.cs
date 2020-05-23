using Ofx.Battleship.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofx.Battleship.Domain.Aggregates.GameAggregate
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }        

        public Guid? GameId { get; set; }
        public Game Game { get; set; }

        public IList<Ship> Ships { get; set; }

        public Player()
        {
            Game = new Game();
            Ships = new List<Ship>();
            CreatedDateTime = DateTime.Now;
            CreatedByUsername = "Api test user";
        }

        public Player(Game game)
        {
            Game = game;
            Ships = new List<Ship>();
        }

        public bool AddShip(int locationX, int locationY, int shipDimensionX, int shipDimensionY)
        {
            var isAdded = false;
            if(CanAddShip(locationX, locationY, shipDimensionX, shipDimensionY))
            {
                Ships.Add(new Ship(locationX, locationY, shipDimensionX, shipDimensionY));
                isAdded = true;
            }
            return isAdded;
        }

        public bool Attack(Location location, Player targetPlayer)
        {
            return Game.Play(Id, location, targetPlayer);
        }

        public bool OnAttack(Location location)
        {
            var isAttackSuccessful = false;

            var ship = Ships.FirstOrDefault(s => s.Location.X <= location.X && s.Location.X + s.DimensionX >= location.X
                                                && s.Location.Y <= location.Y && s.Location.Y + s.DimensionY >= location.Y);
            if(ship != null)
            {
                isAttackSuccessful = ship.OnAttack(location);
            }

            return isAttackSuccessful;
        }

        private bool CanAddShip(int locationX, int locationY, int shipDimensionX, int shipDimensionY)
        {
            bool canAddShip = true;
            //Ship size in board dimensions?
            if(!(Game.BoardX >= locationX && Game.BoardY >= locationY 
                && Game.BoardX >= shipDimensionX && Game.BoardY >= shipDimensionY))
            {
                canAddShip = false;
            }

            //Overlapping with another ship
            if (canAddShip && Ships.Count > 0)
            {
                foreach(var ship in Ships)
                {
                    bool xOverlapping = ship.Location.X <= locationX + shipDimensionX - 1 && locationX <= ship.Location.X + ship.DimensionX - 1;
                    bool yOverlapping = ship.Location.Y <= locationY + shipDimensionY - 1 && locationY <= ship.Location.Y + ship.DimensionY - 1;
                    if (xOverlapping && yOverlapping)
                    {
                        canAddShip = false;
                        break;
                    }
                }
            }

            return canAddShip;
        }
    }
}
