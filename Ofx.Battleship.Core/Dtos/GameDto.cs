using System;
using System.Collections.Generic;

namespace Ofx.Battleship.Core.Dtos
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public IList<PlayerDto> Players { get; set; }
    }
}
