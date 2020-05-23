using Microsoft.EntityFrameworkCore;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using Ofx.Battleship.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ofx.Battleship.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly BattleshipContext _context;

        public IUnitOfWork UnitOfWork { get {
                return _context;
            } 
        }

        public GameRepository(BattleshipContext context)
        {
            _context = context;
        }

        public async Task Add(Game game)
        {
            game.CreatedDateTime = DateTime.Now;
            game.CreatedByUsername = "Api test user";
            await _context.AddAsync(game);
        }

        public Task<IList<Player>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetForPlayerAsync(Guid playerId)
        {
            return await _context
                                .Games.Include(g => g.Players).ThenInclude(p => p.Ships).ThenInclude(s => s.ShipParts)
                                .FirstOrDefaultAsync( g => g.Players.Any(p => p.Id == playerId));
        }

        public void Update(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
        }
    }
}
