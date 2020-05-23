using System.Threading;
using System.Threading.Tasks;

namespace Ofx.Battleship.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
