using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Ofx.Battleship.Domain.Repositories
{
    public interface IReadOnlyRepository
    {
        IList<T> ExecuteSql<T>(string sql, Func<DbDataReader, T> map);
    }
}
