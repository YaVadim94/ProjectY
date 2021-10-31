using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Data.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : EntityBase
    {
        protected QueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IReadOnlyCollection<T>> GetAll()
        {
            try
            {
                var entityName = typeof(T).Name;
                var query = $"SELECT * FROM \"{entityName}\"";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<T>(query)).ToList();
            }
            catch (Exception e)
            {
                throw
                    new Exception(e.Message, e); // наверное, здесь стоит обернуть в какой то кастомный экз, чтобы ловить его выше
            }
        }

        public async Task<T> GetById(long id)
        {
            try
            {
                var entityName = typeof(T).Name;
                var query = $"SELECT * FROM \"{entityName}\" WHERE \"Id\" = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
            }
            catch (Exception e)
            {
                throw
                    new Exception(e.Message, e); // наверное, здесь стоит обернуть в какой то кастомный экз, чтобы ловить его выше
            }
        }
    }
}
