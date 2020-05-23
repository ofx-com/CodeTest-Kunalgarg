using Microsoft.EntityFrameworkCore;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using Ofx.Battleship.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ofx.Battleship.Data.Repositories
{
    public class ShipRepository : IShipRepository
    {
        private readonly BattleshipContext _context;

        public IUnitOfWork UnitOfWork { get {
                return _context;
            } 
        }

        public ShipRepository(BattleshipContext context)
        {
            _context = context;
        }

        public async Task Add(Ship ship)
        {
            ship.CreatedDateTime = DateTime.Now;
            ship.CreatedByUsername = "Api test user";
            await _context.AddAsync(ship);
        }

        public Task<IList<Player>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetAsync(int playerId)
        {
            return null;
            //return await _context
            //                    .Players
            //                    .FirstOrDefaultAsync(j => j.Id == playerId);
        }

        public void Update(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
        }
    }
}
