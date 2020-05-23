using AutoMapper;
using MediatR;
using Ofx.Battleship.Core.Dtos;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using Ofx.Battleship.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Ofx.Battleship.Cqs.Commands
{
    public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, GameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public CreateBoardCommandHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameDto> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var game = new Game(request.BoardX, request.BoardY);
            await _gameRepository.Add(game);
            await _gameRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            var gameDto = _mapper.Map<GameDto>(game);
            return gameDto;
        }
    }
}
