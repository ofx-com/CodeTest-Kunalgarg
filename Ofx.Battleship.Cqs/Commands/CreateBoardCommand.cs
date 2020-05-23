using MediatR;
using Ofx.Battleship.Core.Dtos;

namespace Ofx.Battleship.Cqs.Commands
{
    public class CreateBoardCommand : IRequest<GameDto>
    {    
        public int BoardX { get; set; }

        public int BoardY { get; set; }
        public CreateBoardCommand()
        {
            
        }

    }
}
