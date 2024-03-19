using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDesafio.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogDesafio.Repository
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;

        public TagRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public Tag GetTagForName(string name)
        {
            var query = @"SELECT * FROM [Tag] WHERE Name LIKE @name";

            return _connection.QueryFirstOrDefault<Tag>(query, new { Nome = name });
        }
    }
}