using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using System;
using System.Threading.Tasks;

namespace Ofx.Battleship.Domain.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Task Add(Game player);

        Task<Game> GetForPlayerAsync(Guid playerId);
    }
}
