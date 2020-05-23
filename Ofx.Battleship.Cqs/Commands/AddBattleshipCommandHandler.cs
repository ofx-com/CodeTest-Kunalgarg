using MediatR;
using Ofx.Battleship.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Ofx.Battleship.Cqs.Commands
{
    public class AddBattleshipCommandHandler : IRequestHandler<AddBattleshipCommand, bool>
    {
        private readonly IPlayerRepository _playerRepository;


        public AddBattleshipCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> Handle(AddBattleshipCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetAsync(request.PlayerId);
            var isSuccess = player.AddShip(request.Location.X, request.Location.Y, request.ShipDimensionX, request.ShipDimensionY);
            if (isSuccess)
            {
                await _playerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            return isSuccess;
        }
    }
}
