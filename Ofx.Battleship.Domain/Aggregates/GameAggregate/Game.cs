using Ofx.Battleship.Domain.Common;
using System;
using System.Collections.Generic;

namespace Ofx.Battleship.Domain.Aggregates.GameAggregate
{
    public class Game : BaseEntity, IAggregateRoot
    {
        //Game board, default size is 10 X 10
        public int BoardX { get; set; }

        public int BoardY { get; set; }

        public IList<Player> Players { get; set; }
        public Guid? NextTurnPlayerId { get; set; }

        public Game()
        {
            BoardX = 10;
            BoardY = 10;
            Players = new List<Player>();
        }

        public Game(int boardX, int boardY)
        {
            BoardX = boardX;
            BoardY = boardY;
            Players = new List<Player>();
            Players.Add(new Player());
            Players.Add(new Player());
        }

        public bool Play(Guid sourcePlayerId, Location targetLocation, Player targetPlayer)
        {
            var response = false;
            if (NextTurnPlayerId == null || NextTurnPlayerId == sourcePlayerId)
            {
                response = targetPlayer?.OnAttack(targetLocation) ?? false;
                NextTurnPlayerId = targetPlayer?.Id;
            }
            return response;
        }


    }

}
