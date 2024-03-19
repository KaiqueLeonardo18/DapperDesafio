using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDesafio.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogDesafio.Repository
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();
            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            return users;
        }

        public User GetUserForName(string nome)
        {
            var query = @"SELECT * FROM [User] WHERE Name LIKE @nome";

            return _connection.QueryFirstOrDefault<User>(query, new { Nome = nome });
        }

        public void GetUserForNameLike(string nome)
        {
            var query = @"SELECT * FROM [User] WHERE Name LIKE @nome";

            var user = _connection.Query(query, new
            {
                nome = $"%{nome}%"
            });

            foreach (var item in user)
                Console.WriteLine($"{item.Name}");
        }
    }
}