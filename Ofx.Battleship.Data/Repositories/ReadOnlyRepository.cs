using Microsoft.EntityFrameworkCore;
using Ofx.Battleship.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Ofx.Battleship.Data.Repositories
{
    public class ReadOnlyRepository : IReadOnlyRepository
    {
        private readonly BattleshipContext _context;

        public ReadOnlyRepository(BattleshipContext context)
        {
            _context = context;
        }

        public IList<T> ExecuteSql<T>(string sql, Func<DbDataReader, T> map)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    
                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        var entities = new List<T>();

                        while (result.Read())
                        {
                            entities.Add(map(result));
                        }

                        return entities;
                    }
                }
            }
        }
    }
}
