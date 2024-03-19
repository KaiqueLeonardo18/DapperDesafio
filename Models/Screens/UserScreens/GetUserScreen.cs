using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.UserScreens
{
    public class GetUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Busca de Usuário por nome");
            Console.WriteLine("---------------------");
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            GetUserForName(nome);
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static User GetUserForName(string? nome)
        {
            var repository = new UserRepository(Database.connection);
            var user = repository.GetUserForName(nome);

            Console.WriteLine($"{user.Id} - {user.Name}");

            return user;
        }
    }
}