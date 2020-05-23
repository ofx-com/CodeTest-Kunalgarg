using Microsoft.EntityFrameworkCore;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using Ofx.Battleship.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ofx.Battleship.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BattleshipContext _context;

        public IUnitOfWork UnitOfWork { get {
                return _context;
            } 
        }

        public PlayerRepository(BattleshipContext context)
        {
            _context = context;
        }

        public Player Add(Player player)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Player>> GetAll(Guid gameId)
        {
            return await _context
                               .Players.Include(p => p.Game.Players).ThenInclude(p => p.Ships).ThenInclude(s => s.ShipParts).Include(p => p.Ships).ThenInclude(s => s.ShipParts)
                               .Where(p => p.GameId == gameId).ToListAsync();
        }

        public async Task<Player> GetAsync(Guid playerId)
        {
            return await _context
                                .Players.Include(p => p.Game.Players).ThenInclude(p => p.Ships).ThenInclude(s => s.ShipParts).Include(p => p.Ships).ThenInclude(s => s.ShipParts)
                                .FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public void Update(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
        }
    }
}
