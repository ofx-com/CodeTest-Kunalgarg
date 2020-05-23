using AutoMapper;
using Ofx.Battleship.Core.Dtos;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;

namespace Ofx.Battleship.Cqs
{
    public class BattleshipProfile : Profile
    {
        public BattleshipProfile()
        {
            CreateMap<Game, GameDto>();

            CreateMap<Player, PlayerDto>();
        }
    }
}
