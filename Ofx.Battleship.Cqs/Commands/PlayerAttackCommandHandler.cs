using MediatR;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using Ofx.Battleship.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ofx.Battleship.Cqs.Commands
{
    public class PlayerAttackCommandHandler : IRequestHandler<PlayerAttackCommand, bool>
    {
        private readonly IPlayerRepository _playerRepository;


        public PlayerAttackCommandHandler(IPlayerRepository gameRepository)
        {
            _playerRepository = gameRepository;
        }

        public async Task<bool> Handle(PlayerAttackCommand request, CancellationToken cancellationToken)
        {            
            var player = await _playerRepository.GetAsync(request.PlayerId);

            var players = await _playerRepository.GetAll(player.GameId.Value);
            var isSuccess = players.FirstOrDefault(p => p.Id == request.PlayerId).Attack(new Location(request.Location.X, request.Location.Y), players.FirstOrDefault(p => p.Id != request.PlayerId));
            await _playerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return isSuccess;
        }
    }
}
