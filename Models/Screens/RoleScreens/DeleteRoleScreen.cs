using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.RoleScreens
{
    public class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma Role");
            Console.WriteLine("---------------------");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            Delete(new Role
            {
                Id = int.Parse(id)
            });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void Delete(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.connection);
                repository.Delete(role);
                Console.WriteLine("Role deletada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a Role");
                Console.WriteLine(ex.Message);
            }
        }
    }
}