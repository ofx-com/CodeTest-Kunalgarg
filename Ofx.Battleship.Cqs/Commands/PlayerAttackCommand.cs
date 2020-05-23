using MediatR;
using Ofx.Battleship.Core.Dtos;
using System;

namespace Ofx.Battleship.Cqs.Commands
{
    public class PlayerAttackCommand : IRequest<bool>
    {    
        public Guid PlayerId { get; set; }

        public LocationDto Location { get; set; }

        public PlayerAttackCommand()
        {
            
        }

    }
}
