using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ofx.Battleship.Domain.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player> GetAsync(Guid playerId);

        Task<IList<Player>> GetAll(Guid gameId);

        Player Add(Player player);

        void Update(Player player);
    }
}
