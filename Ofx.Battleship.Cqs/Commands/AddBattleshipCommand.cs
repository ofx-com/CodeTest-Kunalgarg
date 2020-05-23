using MediatR;
using Ofx.Battleship.Core.Dtos;
using System;

namespace Ofx.Battleship.Cqs.Commands
{
    public class AddBattleshipCommand : IRequest<bool>
    {    
        public Guid PlayerId { get; set; }

        public int ShipDimensionX { get; set; }

        public int ShipDimensionY { get; set; }
        public LocationDto Location { get; set; }
        public AddBattleshipCommand()
        {
            
        }

    }
}
