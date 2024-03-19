using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.UserScreens
{
    public class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um usuário");
            Console.WriteLine("---------------------");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            Delete(new User
            {
                Id = int.Parse(id!)
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Delete(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Delete(user);
                Console.WriteLine("Usuário deletado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível deletar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}