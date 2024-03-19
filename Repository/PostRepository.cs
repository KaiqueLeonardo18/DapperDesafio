using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDesafio.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogDesafio.Repository
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public Post GetPostForSlug(string slug)
        {
            var query = @"SELECT * FROM [Post] WHERE Name LIKE @slug";

            return _connection.QueryFirstOrDefault<Post>(query, new { Slug = slug });
        }
    }
}