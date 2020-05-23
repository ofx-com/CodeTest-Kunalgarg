using Ofx.Battleship.Domain.Common;

namespace Ofx.Battleship.Domain.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        IUnitOfWork UnitOfWork { get;}
    }
}
