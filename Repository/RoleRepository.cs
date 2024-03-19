using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDesafio.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogDesafio.Repository
{
    public class RoleRepository : Repository<Role>
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public Role GetRoleForName(string nome)
        {
            var query = @"SELECT * FROM [Role] WHERE Name LIKE @nome";

            return _connection.QueryFirstOrDefault<Role>(query, new { Nome = nome });
        }
    }
}