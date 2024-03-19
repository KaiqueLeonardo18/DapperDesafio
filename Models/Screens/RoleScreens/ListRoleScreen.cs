using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.RoleScreens
{
    public class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Roles");
            Console.WriteLine("---------------------");
            List();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }
        private static void List()
        {
            var repository = new Repository<Role>(Database.connection);
            var roles = repository.Get();

            foreach (var item in roles)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }


}