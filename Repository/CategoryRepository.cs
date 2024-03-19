using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDesafio.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogDesafio.Repository
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public Category GetCategoryByName(string name)
        {
            var query = @"SELECT * FROM [Category] WHERE Name LIKE @name";

            return _connection.QueryFirstOrDefault<Category>(query, new { Slug = name });
        }
    }
}