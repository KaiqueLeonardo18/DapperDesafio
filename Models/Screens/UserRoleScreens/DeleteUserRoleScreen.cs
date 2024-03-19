using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.UserRoleScreens
{
    public class DeleteUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um vinculado de usuário e perfil");
            Console.WriteLine("---------------------");
            Console.WriteLine("Id do usuário:");
            var idUser = Console.ReadLine();

            Console.WriteLine("Id do Role:");
            var idRole = Console.ReadLine();

            Delete(new UserRole
            {
                UserId = int.Parse(idUser),
                RoleId = int.Parse(idRole)
            });
            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        private static void Delete(UserRole userRole)
        {
            var repository = new Repository<UserRole>(Database.connection);
            repository.Delete(userRole);
            Console.WriteLine("Vinculado de usuário e role excluído com sucesso!");
        }
    }
}