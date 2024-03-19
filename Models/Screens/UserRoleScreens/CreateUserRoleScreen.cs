using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.UserRoleScreens
{
    public class CreateUserRoleScreen
    {
        public static void Load()
        {
            Console.WriteLine("Novo vinculo de usuário e perfil");
            Console.WriteLine("Nome usuário: ");
            var userName = Console.ReadLine();
            var user = UserLink(userName);

            if (user is null)
            {
                Console.WriteLine("Usuário não encontrado");
            }

            Console.WriteLine("Nome usuário: ");
            var roleName = Console.ReadLine();
            var role = RoleLink(roleName);
            if (role is null)
            {
                Console.WriteLine("Role não encontrado");
                Load();
            }

            Create(new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            });
        }

        public static User UserLink(string name)
        {
            try
            {
                var repositoryUser = new UserRepository(Database.connection);
                return repositoryUser.GetUserForName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Houve um erro ao procurar o usuário");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static Role RoleLink(string name)
        {
            try
            {
                var repositoryUser = new RoleRepository(Database.connection);
                return repositoryUser.GetRoleForName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Houve um erro ao procurar o role");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static void Create(UserRole userRole)
        {
            try
            {
                var repository = new Repository<UserRole>(Database.connection);
                repository.Create(userRole);
                Console.WriteLine("Usuário vinculado a uma role com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular o usuário e a role");
                Console.WriteLine(ex.Message);
            }
        }
    }
}