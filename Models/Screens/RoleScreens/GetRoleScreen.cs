using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.RoleScreens
{
    public class GetRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Busca de Role por nome");
            Console.WriteLine("---------------------");
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            GetRoleForName(nome);
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static Role GetRoleForName(string? nome)
        {
            var repository = new RoleRepository(Database.connection);
            var role = repository.GetRoleForName(nome);

            Console.WriteLine($"{role.Id} - {role.Name}({role.Slug})");

            return role;
        }
    }
}