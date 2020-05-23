using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using System.Threading.Tasks;

namespace Ofx.Battleship.Domain.Repositories
{
    public interface IShipRepository : IRepository<Ship>
    {
        Task Add(Ship ship);
    }
}
